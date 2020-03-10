using Automation_TrainingM10B.Test_Cases;
using Newtonsoft.Json;
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
    class APIUtilities:BaseTest

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
        public void initTest()
        {
            Console.WriteLine("Starts: " + DateTime.Now);
            getMethod = "GET";
            postMethod = "POST";
            contentType = "application/json";
            keepAlive = false;
        }

        public void GetTest(String url)
        {
            Console.WriteLine("Get: " + url);
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
                        Console.WriteLine("Error: " + e.Message);
                        response = new GetResponse();
                        response.status = "Failed";
                    }
                }
                HttpResponse.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while getting the URL:" + e.Message);
                response = new GetResponse();
                response.status = "Failed Request";
            }
            if (response.data != null)
            {
                foreach (Employee employee in response.data)
                {
                    Console.WriteLine($"id: {employee.id}, Name: {employee.employee_name}, Age: {employee.employee_age}");

                }
            }
            Console.WriteLine($"Status: {response.status}");
            Console.WriteLine(dataJsonGet);
        }

        public void PostTest(String url, String bodyParameter)
        {
            Console.WriteLine("Starting Post: " + url);
            Console.WriteLine("Data: " + bodyParameter);
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
                Console.WriteLine($"Status: {HttpResponse.StatusCode}");
                using (DataStream = HttpResponse.GetResponseStream())
                {
                    DataReader = new StreamReader(DataStream);
                    dataJsonPost = DataReader.ReadToEnd();
                }
                HttpResponse.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.WriteLine(dataJsonPost);
        }
    }
}
