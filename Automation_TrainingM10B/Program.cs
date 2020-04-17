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
        /*   static void Main(string[] args)
           {
           //////////////////////////////////////////////////////////
               //Exercise 01
           //////////////////////////////////////////////////////////

               string[] arr1 = new string[]
           {
               "One",
               "Two",
               "Three"
           };


               //int n, i;
               Console.Write("\nLINQ : Print the lenght of the strings in the array : ");
               Console.Write("\n------------------------------------------------------\n");
               //Write Your code
               Console.WriteLine(arr1.Length);
               Console.ReadLine();
           }*/



        static void Main(string[] args)
        {

            //////////////////////////////////////////////////////////
            //Exercise 02
            //////////////////////////////////////////////////////////
            ///
            //Directory of Files
            string[] dirfiles = Directory.GetFiles("C:/LINQFiles/");
            
            Console.Write("\nLINQ : Calculate the Size of File : ");
            Console.Write("\n------------------------------------\n");
            //Write Your code
            long length = new System.IO.FileInfo("C:/LINQFiles/FileSize01.txt").Length;
            long length2 = new System.IO.FileInfo("C:/LINQFiles/FileSize02.txt").Length;
            long length3 = new System.IO.FileInfo("C:/LINQFiles/FileSize03.txt").Length;
            Console.WriteLine("The file size is {0} Bytes", length);
            Console.WriteLine("The file size is {0} Bytes", length2);
            Console.WriteLine("The file size is {0} Bytes", length3);
            Console.ReadLine();
        }


        /* static void Main()
         {

            //////////////////////////////////////////////////////////
            //Exercise 03
            //////////////////////////////////////////////////////////
            
             // The first part is Data source.
             int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
             Console.Write("\nBasic structure of LINQ : ");
             Console.Write("\n---------------------------");
             //Write Your code

             // Second part: Query creation.
             var nQuery =
                 from vNum in n1
                 select vNum;

             // Third part: Query execution.

             Console.Write("\nNumbers: \n");
             foreach (int vNum in nQuery)
             {
                 Console.Write("{0} ", vNum);
             }
             Console.Write("\n\n");
             Console.ReadLine();
         }*/

        /* 
         * static void Main(string[] args)
         {

            //////////////////////////////////////////////////////////
            //Exercise 04
            //////////////////////////////////////////////////////////
            

             string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
             Console.Write("\nLINQ : Display the name of the days of a week : ");
             Console.Write("\n------------------------------------------------\n");
             //Write Your code

             var days = from WeekDay in dayWeek
                        select WeekDay;
             foreach (var WeekDay in days)
             {
                 Console.WriteLine(WeekDay);
             }
             Console.WriteLine();
             Console.ReadLine();
         }*/



        /* static void Main(string[] args)
         {

            //////////////////////////////////////////////////////////
            //Exercise 05
            //////////////////////////////////////////////////////////
            

             var arr1 = new[] { 3, 9, 2, 8, 6, 5 };
             Console.Write("\nLINQ : Print the number and its square from an array: ");
             Console.Write("\n------------------------------------------------------------------------\n");
             //Write Your code

             var sqNum = from int Number in arr1
                        let SqrNo = Number * Number
                        select new { Number, SqrNo };

             foreach (var a in sqNum)
             Console.WriteLine(a);
             Console.ReadLine();

         }*/

    }
}