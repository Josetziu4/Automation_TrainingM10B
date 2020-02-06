using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Automation_TrainingM10B.Reporting;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Oracle.ManagedDataAccess.Client;

namespace Automation_TrainingM10B.Base_Files
{
    class BaseTest
    {
        public IWebDriver driver;
        public string url;
        public string username;
        public string password;

        public ReportManager manager;
        public ExtentV3HtmlReporter htmlReporter;
        public ExtentReports extent;

        public ExtentTest exTestSuite;
        public ExtentTest exTestCase;
        public ExtentTest exTestStep;

        public OracleConnection dbConnection;
        private string strConnectionString;
        public OracleCommand dbCommand;
        public OracleDataReader dbReader;

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

            strConnectionString = $"User Id={Environment.GetEnvironmentVariable("bpAuto_OracleUser", EnvironmentVariableTarget.User)};" +
                $"password={Environment.GetEnvironmentVariable("bpAuto_OraclePassword", EnvironmentVariableTarget.User  )};" +
                $"Data Source=tytora-n01.brierley.com:1521/bpqa01;" +
                $"Pooling=false;";
            dbConnection = new OracleConnection(strConnectionString);
            try
            {
                dbConnection.Open();
            }
            catch(Exception x)
            {
                Console.Write(x.Message);
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
            //driver.Close();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            dbConnection.Close();
            extent.Flush();
            //driver.Quit();
        }

        //https://web.microsoftstream.com/channel/117d40ec-742b-4c05-9c28-6bf04a4df2d8
    }
}
