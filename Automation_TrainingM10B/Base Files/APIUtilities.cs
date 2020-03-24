using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Renci.SshNet.Sftp;
using System.Net;
using NUnit.Framework;
using Newtonsoft.Json;
using Automation_TrainingM10B.Test_Cases;


namespace Automation_TrainingM10B.Base_Files
{
    class APIUtilities
    {
        HttpWebRequest HttpRequest;
        HttpWebResponse HttpResponse;

        Stream DataStream;
        StreamReader DataReader;
        StreamWriter DataWriter;
        string dataJsonGet;
        string dataJsonPost;
        private String getMethod;
        private String postMethod;
        private String contentType;
        private Boolean keepAlive;

        [SetUp]
        public void beforeTest()
        {
            getMethod = "GET";
            postMethod = "POST";
            contentType = "application/json";
            keepAlive = false;
        }

        public void GetMethodTest(String url)
        {
            HttpRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpRequest.Method = this.getMethod;
            HttpRequest.ContentType = this.contentType;
            HttpRequest.KeepAlive = this.keepAlive;

            GetResponse response = null;
            try
            {
                HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();


                using (DataStream = HttpResponse.GetResponseStream())
                {
                    DataReader = new StreamReader(DataStream);
                    dataJsonGet = DataReader.ReadToEnd();
                    try
                    {
                        response = JsonConvert.DeserializeObject<GetResponse>(dataJsonGet);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Fail Parsing" + e.Message);
                        response = new GetResponse();
                        response.status = "Fail Parsing";
                    }

                }
                HttpResponse.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Please check an error occurred when requesting a URL" + e.Message);
                response = new GetResponse();
                response.status = "Fail to Request URL";
            }
            if (response.data != null)
            {
                foreach (Employee employee in response.data)
                {
                    Console.WriteLine($"id: {employee.id}, Name: {employee.employee_name}, Age: {employee.employee_age}");

                }
            }

            Console.WriteLine($"Status of Request: {response.status}");
            Console.WriteLine(dataJsonGet);
        }

        public void PostMethodTest(String url, String bodyParameter)
        {
            Console.WriteLine("Parameters: " + bodyParameter);
            HttpRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpRequest.Method = this.postMethod;
            HttpRequest.ContentType = this.contentType;
            HttpRequest.KeepAlive = this.keepAlive;


            try
            {
                using (DataStream = HttpRequest.GetRequestStream())
                {
                    DataWriter = new StreamWriter(DataStream);
                    DataWriter.Write(bodyParameter);
                    DataWriter.Flush();
                }
                HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();
                Console.WriteLine($"Status of Request: {HttpResponse.StatusCode}");
                using (DataStream = HttpResponse.GetResponseStream())
                {
                    DataReader = new StreamReader(DataStream);
                    dataJsonPost = DataReader.ReadToEnd();
                }
                HttpResponse.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Please check an error occurred when requesting a URL" + e.Message);
            }

            Console.WriteLine(dataJsonPost);
        }
    }
}
