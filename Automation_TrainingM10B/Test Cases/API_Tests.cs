using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;

namespace Automation_TrainingM10B.Test_Cases
{
    class API_Tests
    {
        HttpWebRequest HttpRequest;
        HttpWebResponse HttpResponse;

        Stream DataStream;
        StreamReader DataReader;
        StreamWriter DataWriter;

        string Payload;

        [Test]
        public void GetTest()
        {
            HttpRequest = (HttpWebRequest)WebRequest.Create("http://dummy.restapiexample.com/api/v1/employees");
            HttpRequest.Method = "GET";
            HttpRequest.ContentType = "application/json";
            HttpRequest.KeepAlive = false;

            HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();

            using(DataStream = HttpResponse.GetResponseStream())
            {
                DataReader = new StreamReader(DataStream);
                Payload = DataReader.ReadToEnd();
            }
            HttpResponse.Close();

            Console.WriteLine(Payload);
        }
    }
}
