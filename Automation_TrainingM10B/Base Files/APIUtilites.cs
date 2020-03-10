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
using Renci.SshNet;
using System.Net;
using System.IO;
using System.Web;

namespace Automation_TrainingM10B.Base_Files
{
    class APIUtilites 
    {
        public string endpoint = "http://dummy.restapiexample.com/api/v1/";
        HttpWebRequest HttpRequest;
        HttpWebResponse HttpResponse;

        Stream DataStream;
        StreamReader DataReader;
        StreamWriter DataWriter;

        string Payload;

            //METHODS//

            //Get Method//
            public void FnGet(string pstrGet)
        {
            try
            {
                HttpRequest = (HttpWebRequest)WebRequest.Create(endpoint+pstrGet);
                HttpRequest.Method = "GET";
                HttpRequest.ContentType = "application/json";
                HttpRequest.KeepAlive = false;

                HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();

                using (DataStream = HttpResponse.GetResponseStream())
                {
                    DataReader = new StreamReader(DataStream);
                    Payload = DataReader.ReadToEnd();

                }

            }

            catch (Exception x)
            {
                Console.Write(x.Message);
            }
        }


        //Post Method//
        public void FnPost(string pstrPost, string pstrbody)
        {
            try
            {
                string body = pstrbody;
                
                HttpRequest = (HttpWebRequest)WebRequest.Create(endpoint + pstrPost);
                HttpRequest.Method = "POST";
                HttpRequest.ContentType = "application/json";
                HttpRequest.KeepAlive = false;

                HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();

                using (DataStream = HttpRequest.GetRequestStream())
                {
                    DataWriter = new StreamWriter(DataStream);
                    DataWriter.Write(body);
                    DataWriter.Flush();
                }

                HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();

                using (DataStream = HttpResponse.GetResponseStream())
                {
                    DataReader = new StreamReader(DataStream);
                    Payload = DataReader.ReadToEnd();
                }
            }

            catch (Exception x)
            {
                Console.Write(x.Message);
            }                    
        }


        //Write Method//
        public void FnWrite()
        {
            HttpResponse.Close();
            Console.WriteLine(Payload);
           
        }


       }


    }



