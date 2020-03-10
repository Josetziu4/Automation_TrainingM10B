using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;
using Automation_TrainingM10B.Base_Files;
using Renci.SshNet.Sftp;

namespace Automation_TrainingM10B.Test_Cases
{
    class APITests:APIUtilites
    {

        APIUtilites objTest = new APIUtilites();

        //Get API Test//
        [Test]
        public void Get()
        {
            objTest.FnGet("employee");
            objTest.FnWrite();
        }    

        //Get Post Test//
        [Test]
        public void Post()
        {
            
            objTest.FnPost("create");
            objTest.FnWrite();

        }

        
        
        
    }
}
