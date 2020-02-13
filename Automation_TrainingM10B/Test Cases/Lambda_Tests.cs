using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Test_Cases
{
    class Lambda_Tests
    {
        int lessThan = 5;
        List<int> numbers = new List<int>() { 1, 7, 4, 2, 5, 3, 9, 8, 6 };

        [Test]
        public void Lambda_Test()
        {
            IEnumerable<int> evensMethod = numbers.Where(IsEven); //METHOD
            IEnumerable<int> evensDelegate = numbers.Where(delegate (int number) { return (number % 2 == 0); }); //DELEGATE
            IEnumerable<int> evensLambda = numbers.Where(number => number < lessThan); // LAMBDA
            Func<int, int, int> test = (a, b) => a + b;
            var x = test(10,11);
            x = test(4,11);
        }

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

        public int HypoteneuseSquared(int x, int y)
        {
            return x * x + y * y;
        }
    }
}
