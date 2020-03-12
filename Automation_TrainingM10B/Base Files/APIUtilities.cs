using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Base_Files
{
    class APIUtilities
    {
        //VARIABLES
        public HttpWebRequest objHttpRequest;
        public HttpWebResponse objHttpResponse;
        Stream DataStream;
        StreamReader DataReader;
        StreamWriter DataWriter;
        //BASE URL of the API
        private static string strApiUrl = ConfigurationManager.AppSettings.Get("apiurl");
        private string Payload;
        //GENERATE RANDOM STRING
        StringBuilder str_build = new StringBuilder();
        Random random = new Random();
        char letter;

        //METHODS
        [OneTimeSetUp] //At the start of everything
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
            fnWriteTheResponse(objHttpResponse); //We receive the response to print
        }

        [OneTimeTearDown] // at the end of everything
        public void AfterAllTests()
        {
        }

        //GET
        public HttpWebResponse fnGetMethod(string pstrGetAPI)
        {          
            objHttpRequest = (HttpWebRequest)WebRequest.Create(strApiUrl+ pstrGetAPI); // we send the EndPoint of the GET API
            objHttpRequest.ContentType = "application/json";
            objHttpRequest.KeepAlive = false;
            objHttpRequest.Method = "GET";
            objHttpResponse = (HttpWebResponse)objHttpRequest.GetResponse();
            return objHttpResponse;
        }

        //POST
        public HttpWebResponse fnPostMethod(string pstrPostAPI, string pbody)
        {
            objHttpRequest = (HttpWebRequest)WebRequest.Create(strApiUrl + pstrPostAPI);
            objHttpRequest.ContentType = "application/json";
            objHttpRequest.KeepAlive = false;
            objHttpRequest.Method = "POST";
            using (DataStream = objHttpRequest.GetRequestStream())
            {
                DataWriter = new StreamWriter(DataStream);
                DataWriter.Write(pbody);
            }
            objHttpResponse = (HttpWebResponse)objHttpRequest.GetResponse();
            return objHttpResponse;
        }

        //This method allows you to console write the response contained in the Response Object
        private string fnWriteTheResponse(HttpWebResponse pobjHttpResponse)
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

        //This method generates a random string
        public string fnRandomString(int plenght)
        {
            for (int i = 0; i < plenght; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        //This method generates random number

        public int fnRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}