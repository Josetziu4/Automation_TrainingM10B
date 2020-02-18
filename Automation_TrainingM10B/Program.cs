using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Automation_TrainingM10B
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise1();
            //Exercise2();
            Exercise3();
            //Exercise4();
            //Exercise5();

        }

        private static void Exercise5()
        {
            //5.- Write a program in C# to print the number and its square from an array. 
            var arr1 = new[] { 3, 9, 2, 8, 6, 5 };

            int n = 3;

            var valuesFound = arr1.ToList().FindAll(str => str.Equals(n));

            //foreach (int n in arr1)
            //{
                Console.WriteLine($"The square of {n} is {n*n}");
            //}



            Console.ReadLine();
        }

        private static void Exercise4()
        {
            string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            foreach(string day in dayWeek)
            {
                Console.WriteLine(day);
            }

            Console.ReadLine();
        }

        private static void Exercise3()
        {
            //  The first part is Data source.             
            int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 

            Console.Write("\nBasic structure of LINQ : ");
            Console.Write("\n---------------------------\n");

            int n = 3;

            foreach(int num in n1)
            {
                Console.WriteLine(num);
            }

            var len = from str1 in n1
                      where str1.Equals(n)
                      select str1;

            Console.WriteLine($"The value selected from the the prvious list is {n}");
            Console.ReadLine();
        }

        private static void Exercise2()
        {
            //Write a program in C# to print the size of a file in bytes in a directory using LINQ. 
            string[] dirfiles = Directory.GetFiles(@"C:\Test");             
            // there are three files in the directory abcd are :            
            // abcd.txt, simple_file.txt and xyz.txt 

            Console.Write("\nLINQ : Calculate the Size of File : ");
            Console.Write("\n------------------------------------\n");

            string filename = @"C:\Test\abcd.txt";

            var Getfile = from str1 in dirfiles
                          where str1.Equals(filename)
                          select GetFileLength(str1);

            Console.WriteLine($"The size in bytes of the file {filename} is {Getfile.First()}");



            Console.ReadLine();
        }

        public static long GetFileLength(string filename)
        {
            long retval;
            try
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(filename);
                retval = fi.Length;
            }
            catch (System.IO.FileNotFoundException)
            {
                retval = 0;
            }
            return retval;
        }

        public static void Exercise1()
        {
            //1.- Write a program in C# to print the length of a string from an array of strings. 
            string[] arr1 = {"Liverpool", "Madrid", "Roma", "Paris", "Barcelona"};
            string city;
            //int n, i = 0;

            city = "Barcelona";

            var len = from str1 in arr1
                              where str1.Equals(city)
                              select str1.Length;
            Console.WriteLine($"The length of the string {city} is {len.First()}");

            Console.ReadLine();
            //return element;
        }
    }
}