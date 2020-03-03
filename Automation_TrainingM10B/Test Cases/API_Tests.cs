using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;

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
            GetResponse response;

            using (DataStream = HttpResponse.GetResponseStream())
            {
                DataReader = new StreamReader(DataStream);
                Payload = DataReader.ReadToEnd();

                response = JsonConvert.DeserializeObject<GetResponse>(Payload);
            }
            HttpResponse.Close();

            Console.WriteLine($"Status is: {response.status}");
            foreach(Employee employee in response.data)
            {
                Console.WriteLine($"id: {employee.id}, Name: {employee.employee_name}, Age: {employee.employee_age}");
            }
            //Console.WriteLine(Payload);

        }

        [Test]
        public void PostTest()
        {

            string Body = "{ \"name\":\"test\",\"salary\":\"123\",\"age\":\"23\"}";

            HttpRequest = (HttpWebRequest)WebRequest.Create("http://dummy.restapiexample.com/api/v1/create");
            HttpRequest.Method = "POST";
            HttpRequest.ContentType = "application/json";
            HttpRequest.KeepAlive = false;

            using (DataStream = HttpRequest.GetRequestStream())
            {
                DataWriter = new StreamWriter(DataStream);
                DataWriter.Write(Body);
                DataWriter.Flush();
            }

            HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();

            using (DataStream = HttpResponse.GetResponseStream())
            {
                DataReader = new StreamReader(DataStream);
                Payload = DataReader.ReadToEnd();
            }
            HttpResponse.Close();

            Console.WriteLine(Payload);
        }
    }

    public class Employee
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }

    public class GetResponse
    {
        public string status { get; set; }
        public List<Employee> data { get; set; }
    }
}
