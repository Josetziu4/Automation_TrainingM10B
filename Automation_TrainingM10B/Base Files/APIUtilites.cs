using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation_TrainingM10B.Base_Files
{
    class APIUtilites
    {
        HttpWebRequest HttpRequest;
        HttpWebResponse HttpResponse;

        Stream DataStream;
        StreamReader DataReader;
        StreamWriter DataWriter;

        public IWebDriver driver;
        public string url;
        [OneTimeSetUp]
        public void BeforeAllTests()
        {
           url = Environment.GetEnvironmentVariable("url", EnvironmentVariableTarget.User);
            
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

        string Payload;
        

        public void GetAPI()
        {
            HttpRequest = (HttpWebRequest)WebRequest.Create("http://dummy.restapiexample.com/api/v1/employees");
            //HttpRequest = (HttpWebRequest)WebRequest.Create(url);
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
            foreach (Employee employee in response.data)
            {
                Console.WriteLine($"id: {employee.id}, Name: {employee.employee_name}, Age: {employee.employee_age}");
            }

        }
        public void PostAPI()
        {
            string Body = "{ \"name\":\"test\",\"salary\":\"123\",\"age\":\"23\"}";

            HttpRequest = (HttpWebRequest)WebRequest.Create("http://dummy.restapiexample.com/api/v1/create");
            HttpRequest.Method = "POST";
            HttpRequest.ContentType = "application/json";
            HttpRequest.KeepAlive = false;

            PostResponse response;

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
                //response = JsonConvert.DeserializeObject<List<CustomerJson>>(json);
                response = JsonConvert.DeserializeObject<PostResponse>(Payload);
            }
            HttpResponse.Close();

            //Console.WriteLine(Payload);
            Console.WriteLine($"Status is: {response.status}");
            //foreach (Employee2 employee in response.data)
            //{
            //    Console.WriteLine($"Name: {employee.name}, salary: {employee.salary}, Age: {employee.age}");
            //}
            Console.WriteLine($"Name: {response.data.name}, salary: {response.data.salary}, Age: {response.data.age}");

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

        public class Employee2
        {
           
            public string name { get; set; }
            public string salary { get; set; }
            public string age { get; set; }
            public string id { get; set; }
            
        }
        public class PostResponse
        {
            public string status { get; set; }
            public Employee2 data { get; set; }
        }

    }
}
