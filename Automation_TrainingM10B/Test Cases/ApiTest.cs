﻿using Automation_TrainingM10B.Base_Files;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Test_Cases
{
    class ApiTest:ApiUtilites
    {
       private readonly String urlTestApiGet = "http://dummy.restapiexample.com/api/v1/employees";
       private readonly String urlTestAPiPost = "http://dummy.restapiexample.com/api/v1/create";
       private readonly String BodyParameterPost = "{ \"name\":\"test\",\"salary\":\"123\",\"age\":\"23\"}";

        [Test]
        public void ExecuteUrl()
        {
            Console.WriteLine("******************************************************************");
            GetMethodTest(this.urlTestApiGet);
            Console.WriteLine("******************************************************************");
            PostMethodTest(this.urlTestAPiPost,this.BodyParameterPost);
            Console.WriteLine("******************************************************************");
        }
    }
}
