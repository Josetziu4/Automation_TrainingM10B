using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Automation_TrainingM10B.Data_Models.API_Model;

namespace Automation_TrainingM10B.Base_Files
{
    class APIUtilities : BaseTest
    {
        
        public void GetAPI()
        {
            try
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

                foreach (Employee employee in response.data)
                {
                    Console.WriteLine($"id: {employee.id}, Name: {employee.employee_name}, Age: {employee.employee_age}, Salary: ${employee.employee_salary}");
                }
            }
            catch(Exception ex)
            {
                HttpResponse.Close();
                Console.WriteLine($"POST status is:{HttpResponse.StatusDescription}");
                Console.WriteLine($"Error:{ex}");
            }

        }

        public void PostAPI(string pstrName, double pdblSalary, int pintAge)
        {
            try
            {
                string Body = "{ \"name\":\"" + pstrName + "\",\"salary\":\"" + pdblSalary + "\",\"age\":\"" + pintAge + "\"}";

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

                //Console.WriteLine(Payload);
                Console.WriteLine($"POST status is:{HttpResponse.StatusDescription}");
                Console.WriteLine($"API POST call was successfully done with following data: Name: {pstrName} - Salary: {pdblSalary} - Age: {pintAge}");
            }
            catch(Exception ex)
            {
                HttpResponse.Close();
                Console.WriteLine($"POST status is:{HttpResponse.StatusDescription}");
                Console.WriteLine($"Error:{ex}");
            }
        }

    }
}
