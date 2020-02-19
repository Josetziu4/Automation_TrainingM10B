using AutomationTrainingM10B.Base_Files;
using AutomationTrainingM10B.Page_Objects;
using AutomationTrainingM10B.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B
{
    class Program
    {
        //Delegates
        delegate void LambdasNoParams(); //(1)


        static void Main(string[] args)
        {

            //-------------------------------------------------
            //Excersie 1
            //-------------------------------------------------
            string[] arr1;
            int n, i;

            Console.Write("\nLINQ : Print the lenght of the strings in the array : ");
            Console.Write("\n------------------------------------------------------\n");
            try
            {
                //Write Your code Here
                Console.Write("How many elements will include your array? :");
                n = Convert.ToInt32(Console.ReadLine());
                arr1 = new string[n];
                Console.Write("\nWrite {0} strings for the array  :\n", n);
                for (i = 0; i < n; i++)
                {
                    Console.Write("Word[{0}] : ", i);
                    arr1[i] = Console.ReadLine();
                }

                var strWords = from strElement in arr1
                               select strElement;

                foreach (var strElement in strWords)
                {
                    Console.WriteLine("String {0} contains: {1} chars", strElement, strElement.Length);
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in: \n" + ex.GetBaseException());
            }




            //-------------------------------------------------
            //Excersie 2
            //-------------------------------------------------
            try
            {
                string[] dirfiles = Directory.GetFiles(@"C:\Automation\Documents");
                // there are three files in the directory abcd are :
                // abcd.txt, simple_file.txt and xyz.txt

                Console.Write("\nLINQ : Calculate the Size of File : ");
                Console.Write("\n------------------------------------\n");

                //Write Your code

                if (dirfiles.Count() > 0)
                {
                    Console.WriteLine("Number of files in folder is: " + dirfiles.Count());

                    var files = from file in dirfiles
                                select file;

                    foreach (var file in files)
                    {
                        long size = new FileInfo(file).Length;

                        Console.WriteLine("File Name is: {0}, Size in bytes is: {1}", file
                            , size);

                    }

                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in: \n" + ex.GetBaseException());

            }






            //-------------------------------------------------
            //Excersie 3
            //-------------------------------------------------
            //  The first part is Data source.
            try
            {
                int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int n2 = n1.Count();
                Console.Write("\nBasic structure of LINQ : ");
                Console.Write("\n---------------------------");

                //Write Your code
                var allNumbers = from number in n1
                                 select number;
                Console.WriteLine("All numbers are: ");



                foreach (var Number in allNumbers)
                {
                    Console.WriteLine("number is: {0}", Number);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in: " + ex.Message);

            }
            Console.ReadLine();





            //-------------------------------------------------
            //Excersie 4
            //-------------------------------------------------
            try
            {
                string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

                Console.Write("\nLINQ : Display the name of the days of a week : ");
                Console.Write("\n------------------------------------------------\n");

                //Write Your code
                var allDays = from day in dayWeek
                              select day;
                Console.WriteLine("All days are: ");

                foreach (var Days in allDays)
                {
                    Console.WriteLine("{0}", Days);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in: " + ex.Message);

            }

            Console.ReadLine();





            //-------------------------------------------------
            //Excersie 5
            //-------------------------------------------------

            try
            {
                var arr3 = new[] { 3, 9, 2, 8, 6, 5 };

                Console.Write("\nLINQ : Print the number and its square from an array: ");
                Console.Write("\n------------------------------------------------------------------------\n");

                //Write Your code
                var allNumbers = from number in arr3
                                 select number;
                Console.WriteLine("All numbers are: ");

                foreach (var Number in allNumbers)
                {
                    Console.WriteLine("Number is: {0}", Number);
                    Console.WriteLine("Number square is: {0}", Math.Pow(Number, 2));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in: " + ex.Message);

            }
            Console.ReadLine();

        }
    }
}
