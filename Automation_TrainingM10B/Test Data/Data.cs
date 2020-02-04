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
                yield return new NUnit.Framework.TestCaseData(2, 3).Returns(5);
                yield return new NUnit.Framework.TestCaseData(3, 3).Returns(6);
                yield return new NUnit.Framework.TestCaseData(8, 4).Returns(12);
                yield return new NUnit.Framework.TestCaseData(7, 7).Explicit();
                //Instead of Returns in can be used Explicit, it will only display the result
            }
        }
    }
}
