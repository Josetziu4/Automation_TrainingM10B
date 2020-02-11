using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Test_Cases
{
    class Lambda_Tests
    {
        List<int> numbers = new List<int>() { 1, 7, 4, 2, 5, 3, 9, 8, 6 };

        public static List<int> FindEvenNumbers(List<int> numbers)
        {
            List<int> onlyEvens = new List<int>();
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                    onlyEvens.Add(number);
            }
            return onlyEvens;
        }

        public static bool IsEven(int number)
        {
            return (number % 2 == 0);
        }
    }
}
