using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Test_Cases
{
    class Linq_Tests
    {
        [Test]
        public void Query_Syntax_Example1()
        {
            List<string> values = new List<string>() { "value1", "value2", "value3", "value4", "value5" };

            var valuesFound = from str1 in values
                              where str1.Contains("3")
                              select str1;

            foreach (string element in valuesFound)
                Console.WriteLine($"Matching Element: {element}");
        }

        [Test]
        public void Query_Syntax_Example2()
        {
            List<MultiElement> values = new List<MultiElement>() { new MultiElement() { str = "hello", integer = 1},
                                                                   new MultiElement() { str = "this", integer = 4},
                                                                   new MultiElement() { str = "is", integer = 99},
                                                                   new MultiElement() { str = "training", integer = 50},};

            var value99 = from value in values
                          where value.integer == 99
                          select value;

            Console.WriteLine("Elements with integer == 99");
            foreach (MultiElement element in value99)
                Console.WriteLine($"\tMatching Element: {element.str} {element.integer}");


            value99 = from value in values
                      where value.integer == 99 || value.str.Equals("training")
                      select value;

            Console.WriteLine("Elements with integer == 99 or str == training");
            foreach (MultiElement element in value99)
                Console.WriteLine($"\tMatching Element: {element.str} {element.integer}");
        }


        [Test]
        public void Method_Syntax_Example1()
        {
            List<string> values = new List<string>() { "value1", "value2", "value3", "value4", "value5", "value33" };

            var valuesFound = values.FindAll(str => str.Contains("3"));

            Console.WriteLine("Elements containing '3':");
            foreach (string element in valuesFound)
                Console.WriteLine($"\tMatching Element: {element}");


            string fisrtValueFound = values.Find(str => str.Contains("3"));
            Console.WriteLine("First Element containing 3:");
            Console.WriteLine($"\tMatching Element: {fisrtValueFound}");

            string lastValueFound = values.FindLast(str => str.Contains("3"));
            Console.WriteLine("Last Element containing 3:");
            Console.WriteLine($"\tMatching Element: {lastValueFound}");


        }

        [Test]
        public void Method_Syntax_Example2()
        {
            List<MultiElement> values = new List<MultiElement>() { new MultiElement() { str = "hello", integer = 1},
                                                                   new MultiElement() { str = "this", integer = 4},
                                                                   new MultiElement() { str = "is", integer = 99},
                                                                   new MultiElement() { str = "training", integer = 50},};

            List<MultiElement> foundValues = values.FindAll(x => x.integer == 99);

            Console.WriteLine("Elements with integer == 99");
            foreach (MultiElement element in foundValues)
                Console.WriteLine($"\tMatching Element: {element.str} {element.integer}");


            foundValues = values.FindAll(x => x.integer == 99 || x.str.Equals("training"));

            Console.WriteLine("Elements with integer == 99 or str == training");
            foreach (MultiElement element in foundValues)
                Console.WriteLine($"\tMatching Element: {element.str} {element.integer}");


            foundValues = values.FindAll(x => x.str.Length > 2).OrderByDescending(x => x.integer).ToList();

            Console.WriteLine("Elements with str length > 2, ordered by integer descending");
            foreach (MultiElement element in foundValues)
                Console.WriteLine($"\tMatching Element: {element.str} {element.integer}");
        }

        [Test]
        public void Method_Syntax_Example3()
        {
            List<MultiElement> values = new List<MultiElement>() { new MultiElement() { str = "hello", integer = 1},
                                                                   new MultiElement() { str = "this", integer = 4},
                                                                   new MultiElement() { str = "is", integer = 99},
                                                                   new MultiElement() { str = "training", integer = 50},};

            bool output = true;


            List<string> selectedStrings = values.Select(x => x.str).ToList();

            List<MultiElement> newValueCopy = new List<MultiElement>();


            Console.WriteLine("Select all strings from the list of Multi Elements");
            foreach (string element in selectedStrings)
                Console.WriteLine($"\tSelected Element: {element}");

            List<string> selectWhereStrings = values.Select(multiElement => multiElement.str).Where(stringInList => stringInList.Length > 3).ToList();
            Console.WriteLine("Select all strings longer than 3 chars from the list");
            foreach (string element in selectWhereStrings)
                Console.WriteLine($"\tSelected Element: {element}");


        }
    }

    public class MultiElement
    {
        public string str;
        public int integer = 0;
    }

}