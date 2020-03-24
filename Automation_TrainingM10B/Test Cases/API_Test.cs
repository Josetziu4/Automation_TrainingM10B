using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;
using Automation_TrainingM10B.Base_Files;
using Renci.SshNet.Sftp;
using System.Net;

namespace Automation_TrainingM10B.Test_Cases
{
    class API_Test:BaseTest
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

            Employee_File file = new Employee_File();

            foreach (Employee employee in response.data)
            {
                Console.WriteLine($"id: {employee.id}, Name: {employee.employee_name}, Age: {employee.employee_age}");
                file.Employees.Add(employee);
            }
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

    public class Employee_File
    {
        public string FileName { get; set; }
        public string Header { get; set; }
        public List<Employee> Employees { get; set; }

        public Employee_File()
        {
            FileName = $"EMPLOYEE_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.TXT";
            Header = "Id|Name|Salary|Age|Image";
            Employees = new List<Employee>();
        }
        public void fnCreateFile()
        {
            StreamWriter file = File.CreateText(FileName);
            file.WriteLine(Header);
            foreach (Employee employee in Employees)
            {
                file.WriteLine($"{employee.id}|{employee.employee_name}|{employee.employee_salary}|{employee.employee_age}|{employee.profile_image}");
            }
            file.Close();
        }
    }
}
