using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Base_Files
{
    class APIUtilities
    {
        //VARIABLE
        HttpWebRequest HttpRequest;
        HttpWebResponse HttpResponse;
        Stream DataStream;
        StreamReader DataReader;
        StreamWriter DataWriter;
        string Payload;

        [OneTimeSetUp]
        public void GetTest()
        {

        }

        [SetUp]
        public void BeforeTest()
        {

        }

        [TearDown]
        public void AfterTest()
        {
            
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {

        }

        public void fnGetMethod(string pstrAPIUrl)
        {          
            HttpRequest = (HttpWebRequest)WebRequest.Create(pstrAPIUrl); // we send the URL of the GET API
            HttpRequest.Method = "GET";
            HttpRequest.ContentType = "application/json";
            HttpRequest.KeepAlive = false;

            HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();

            using (DataStream = HttpResponse.GetResponseStream())
            {
                DataReader = new StreamReader(DataStream);
                Payload = DataReader.ReadToEnd();
            }
            HttpResponse.Close();

            Console.WriteLine(Payload);

        }

        public void fnPostMethod()
        {

        }

        public void fnWriteTheResponse()
        {

        }


    }
}
