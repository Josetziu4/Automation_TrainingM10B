﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using AutomationTrainingM10B.Reporting;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Oracle.ManagedDataAccess.Client;
using Renci.SshNet;

namespace AutomationTrainingM10B.Base_Files
{
    class BaseTest
    {
        //SELENIUM
        public IWebDriver driver;
        public string url;
        public string username;
        public string password;
        //REPORT
        public ReportManager manager;
        public ExtentV3HtmlReporter htmlReporter;
        public ExtentReports extent;
        //
        public ExtentTest exTestSuite;
        public ExtentTest exTestCase;
        public ExtentTest exTestStep;
        //DB CONNECTION
        public OracleConnection dbConnection;
        private string strConnectionString;
        public OracleCommand dbCommand;
        public OracleDataReader dbReader;
        //sftp config
        public SftpClient sftpConnection;
        public ConnectionInfo sftpConnectionString;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            url = Environment.GetEnvironmentVariable("url", EnvironmentVariableTarget.User);
            username = Environment.GetEnvironmentVariable("username", EnvironmentVariableTarget.User);
            password = Environment.GetEnvironmentVariable("password", EnvironmentVariableTarget.User);

            manager = new ReportManager();

            extent = new ExtentReports();
            htmlReporter = new ExtentV3HtmlReporter(manager.fnGetReportPath());

            manager.fnReportSetUp(htmlReporter, extent);

            exTestSuite = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //<DB CONNECTION CONFIG
            //strConnectionString = $"User Id={Environment.GetEnvironmentVariable("bpAuto_OracleUser", EnvironmentVariableTarget.User)};" +
            // $"password={Environment.GetEnvironmentVariable("bpAuto_OraclePassword",EnvironmentVariableTarget.User)};"+
            strConnectionString = $"User Id=mku;" +
              $"password=abc_123;" +
              $"Data Source=tytora-n01.brierley.com:1521/bpqa01;" +
              $"Pooling=false;";

            
            //sftpConnectionString = new ConnectionInfo("tytora-n01.brierley.com", 22, Environment.GetEnvironmentVariable("bpAuto_SFTPUser", EnvironmentVariableTarget.User),
            //    new PasswordAuthenticationMethod(Environment.GetEnvironmentVariable("bpAuto_SFTPUser", EnvironmentVariableTarget.User),
            //    Environment.GetEnvironmentVariable("bpAuto_SFTPPassword", EnvironmentVariableTarget.User)));

            sftpConnectionString = new ConnectionInfo("tytora-n01.brierley.com", 22, "mku", new PasswordAuthenticationMethod("mku", "R12345678bc."));

            dbConnection = new OracleConnection(strConnectionString);
            sftpConnection = new SftpClient(sftpConnectionString);
            try
            {
                dbConnection.Open();
                sftpConnection.Connect();
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver();
            driver.Url = url;

            exTestCase = exTestSuite.CreateNode(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {
           
            driver.Close();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            dbConnection.Close();
            extent.Flush();
            sftpConnection.Disconnect();
            //driver.Quit();
        }

        //https://web.microsoftstream.com/channel/117d40ec-742b-4c05-9c28-6bf04a4df2d8
    }
}
