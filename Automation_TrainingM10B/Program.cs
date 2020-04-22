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
            //Excercise 1//
            string[] arr1;
            int n, i;

            Console.Write("\nLINQ : Print the lenght of the strings in the array : ");
            Console.Write("\n------------------------------------------------------\n");
            try
            {
                //Write Your code Here
                Console.Write("Elements to include? :");
                n = Convert.ToInt32(Console.ReadLine());
                arr1 = new string[n];
                Console.Write("\nWrite {0} strings for the array  :\n", n);
                for (i = 0; i < n; i++)
                {
                    Console.Write("Word[{0}] : ", i);
                    arr1[i] = Console.ReadLine();
                }

                var strWord = from strElement in arr1
                               select strElement;

                foreach (var strElement in strWord)
                {
                    Console.WriteLine("String {0} contains: {1} chars", strElement, strElement.Length);
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in: \n" + ex.GetBaseException());
            }


            //Excercise 2//
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
                        long lenght = new FileInfo(file).Length;

                        Console.WriteLine("File Name is: {0}, Size in bytes: {1}", file
                            , lenght);

                    }

                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in: \n" + ex.GetBaseException());

            }


            //Excercise 3//
            //  The first part is Data source.
            try
            {
                int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int n2 = n1.Count();
                Console.Write("\nBasic structure of LINQ : ");
                Console.Write("\n---------------------------");

                //Write Your code
                var varNumbers = from number in n1
                                 select number;
                Console.WriteLine("The Numbers are: ");



                foreach (var Number in varNumbers)
                {
                    Console.WriteLine("number is: {0}", Number);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in: " + ex.Message);

            }
            Console.ReadLine();




            //Excercise 4//
            try
            {
                string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

                Console.Write("\nLINQ : Display the name of the days of a week : ");
                Console.Write("\n------------------------------------------------\n");

                //Write Your code
                var WeekDays = from day in dayWeek
                              select day;
                Console.WriteLine("The Days are: ");

                foreach (var Days in WeekDays)
                {
                    Console.WriteLine("{0}", Days);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in: " + ex.Message);

            }

            Console.ReadLine();



            //Excercise 5//

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