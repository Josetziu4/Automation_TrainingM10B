using Automation_TrainingM10B.Base_Files;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Test_Cases
{
    class APITest : APIUtilities
    {
        private readonly String urlGet = "http://dummy.restapiexample.com/api/v1/employees";
        private readonly String urlPost = "http://dummy.restapiexample.com/api/v1/create";
        private readonly String BodyParameterPost = "{ \"name\":\"Saúl García\",\"salary\":\"99999\",\"age\":\"35\"}";

        [Test]
        public void apiUrl()
        {
            GetTest(this.urlGet);
            PostTest(this.urlPost, this.BodyParameterPost);
            Console.WriteLine("Finished");
        }
    }
}
