using Automation_TrainingM10B.Base_Files;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Test_Cases
{
    class APITests : BaseTest
    {
        APIUtilities objAPI = new APIUtilities();
        [Test]
        public void GetTest()
        {
            try
            {
                objAPI.GetAPI();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test has failed: "+ ex);
            }
        }
        [Test]
        public void PostTest()
        {
            try
            {
                objAPI.PostAPI("Alex JTP3",96255.20,48);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test has failed: " + ex);
            }
        }

    }
}
