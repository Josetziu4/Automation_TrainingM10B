using Automation_TrainingM10B.Base_Files;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Test_Cases
{
    class APITests: APIUtilities
    {
        //Attributes
        //Final Routes of the APIs to test
        //GET APIS
        private string strApiGetEmployees = "employees";    //Get all employee data
        private string strApiGetEmployee = "employee/1";    //Get a single employee data
        //POST APIS
        private string strApiPostEmployee = "create";       //Create new record in database
        private string strApiUpdateEmployee = "update/21";  //Update an employee record
        private string strbody;
        

        [Test, Order(0)]
        public void testGetEmployee()
        {
            objHttpResponse = fnGetMethod(strApiGetEmployee);
        }

        [Test, Order(1)]
        public void testGetEmployees()
        {
            objHttpResponse = fnGetMethod(strApiGetEmployees);
        }

        [Test, Order(2)]
        public void testPostEmployee()
        {
            string rnd_name = fnRandomString(5);
            string rnd_salary = fnRandomNumber(12, 250).ToString();
            string rnd_age = fnRandomNumber(18, 70).ToString();
            objHttpResponse = fnPostMethod(strApiPostEmployee, fnBodyForEmployee(rnd_name, rnd_salary, rnd_age));
        }

        public string fnBodyForEmployee(string pstrName, string pstrSalary, string pstrAge)
        {
            strbody = @"{""name"":"+ "\""+ pstrName + "\","+ @"""salary"":" + "\"" + pstrSalary + "\"," + @"   ""age"":" + "\"" + pstrAge + "\"}";
            return strbody;
        }
        
    }
}
