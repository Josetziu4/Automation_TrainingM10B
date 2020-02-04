using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Automation_TrainingM10B.Test_Data;

namespace Automation_TrainingM10B.Test_Cases
{
    class Data_Driven_Test
    {
        [TestCaseSource(typeof(Data),"sumData")]
        public int Sum_Test(int a, int b)
        {
            int iSum = a + b;
            Console.Write(iSum);
            return iSum;
        }

    }
}
