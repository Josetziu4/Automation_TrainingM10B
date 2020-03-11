using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_TrainingM10B.Base_Files;
using NUnit.Framework;

namespace Automation_TrainingM10B.Test_Cases
{
    class APITests : APIUtilites
    {
        APIUtilites obj;


        [Test]
        public void GetAPITest()
        {
            obj = new APIUtilites();                  
            obj.GetAPI();      
            
        }

        [Test]
        public void PostAPITest()
        {
            obj = new APIUtilites();
            obj.PostAPI();

        }

    }
}
