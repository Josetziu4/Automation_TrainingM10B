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
        private string strApiGetEmployees = "employees";    //Get all employee data
        private string strApiGetEmployee = "employee/1";    //Get a single employee data

        [Test]
        public void testGetEmployee()
        {
            objHttpResponse = fnGetMethod("employees");
        }


    }
}
