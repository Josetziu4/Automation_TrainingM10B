using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 1
            string[] arr1 = { "one", "two", "three", "four" };
            //int n, i;
            Console.Write("\nLINQ : Print the lenght of the strings in the array : ");
            Console.Write("\n------------------------------------------------------\n");

            //Write Your code
            var stringQuery = from str in arr1
                              where str.Length > 0
                              select str;

            foreach (string strItem in stringQuery)
            {
                Console.WriteLine("The string " + strItem + " is " + strItem.Length + " characters long.");
            }

            Console.ReadLine();

            
            //Exercise 2
            string[] dirfiles = Directory.GetFiles("C:/Test");

            // there are three files in the directory abcd are :
            // abcd.txt, simple_file.txt and xyz.txt
            Console.Write("\nLINQ : Calculate the Size of File : ");
            Console.Write("\n------------------------------------\n");


            var fileQuery = dirfiles.Select(file => new FileInfo(file).Length);
            

            foreach (long strFile in fileQuery)
            {
                //var fileSize = dirfiles.Select(file => new FileInfo(file).Length);
                Console.WriteLine("The file has " + strFile + " bytes");
            }

            Console.ReadLine();


            //Exercise 3
            // The first part is Data source.
            int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.Write("\nBasic structure of LINQ : ");
            Console.Write("\n---------------------------\n");

            //Write Your code
            // The second part is the query
            var queryNumber = from numbers in n1
                        select numbers;

            //The thisrd part is the result
            foreach (int numberItem in queryNumber)
            {
                Console.WriteLine("Number: " + numberItem);
            }

            Console.ReadLine();


            //Exercise 4
            string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            Console.Write("\nLINQ : Display the name of the days of a week : ");
            Console.Write("\n------------------------------------------------\n");
            //Write Your code

            var queryDay = from week in dayWeek
                           select week;

            foreach(string weekDay in queryDay)
            {
                Console.WriteLine("Day: " + weekDay);
            }

            Console.ReadLine();


            //Exercise 5
            var arr2 = new[] { 3, 9, 2, 8, 6, 5 };
            Console.Write("\nLINQ : Print the number and its square from an array: ");
            Console.Write("\n------------------------------------------------------------------------\n");
            //Write Your cod
            var queryNum = from numberList in arr2
                           select new { numberList, square = numberList * numberList };

            foreach (var numList in queryNum)
            {
                Console.WriteLine("Number and its square: " + numList);
            }

            Console.ReadLine();
        }
    }
}
