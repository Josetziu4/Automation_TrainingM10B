using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Test_Data
{
    class Data
    {
        public static IEnumerable sumData
        {
            get
            {
                yield return new TestCaseData(2, 2).Returns(4);//yield hace que regrese a la prueba, ejecuta las instrucciones y entonces regresa al siguiente yield
                yield return new TestCaseData(5, 2).Returns(7);
                yield return new TestCaseData(8, 4).Returns(12);//se puede usar Explicit() este no espera que devuelva nada.
            }
        }
    }
}
