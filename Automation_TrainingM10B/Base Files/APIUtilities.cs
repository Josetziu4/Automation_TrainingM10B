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
        HttpWebRequest objHttpRequest;
        HttpWebResponse objHttpResponse;
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

        //This method allows us to send the url of the API and return the response as an Object
        public HttpWebResponse fnGetMethod(string pstrAPIUrl)
        {          
            objHttpRequest = (HttpWebRequest)WebRequest.Create(pstrAPIUrl); // we send the URL of the GET API
            objHttpRequest.Method = "GET";
            objHttpRequest.ContentType = "application/json";
            objHttpRequest.KeepAlive = false;
            objHttpResponse = (HttpWebResponse)objHttpRequest.GetResponse();
            return objHttpResponse;
        }

        //This method allows you to console write the response contained in the Response Object
        public string fnWriteTheResponse(HttpWebResponse pobjHttpResponse)
        {
            using (DataStream = pobjHttpResponse.GetResponseStream())
            {
                DataReader = new StreamReader(DataStream);
                Payload = DataReader.ReadToEnd();
            }
            pobjHttpResponse.Close();
            Console.WriteLine(Payload);
            return Payload;
        }


        public void fnPostMethod()
        {

        }

        public void fnWriteTheResponse()
        {

        }


    }
}
