using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Automation_TrainingM10B.Test_Data
{
    class Data
    {
        public static IEnumerable sumData
        {
            get
            {
                yield return new TestCaseData(2, 2).Returns(4);
                yield return new TestCaseData(2, 3).Returns(5);
                yield return new TestCaseData(4, 2).Returns(6);
                //yield return new TestCaseData(4, 2).Explicit();
            }

        }
    }
}
