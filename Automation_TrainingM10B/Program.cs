using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace Automation_TrainingM10B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.- Write a program in C# to print the length of a string from an array of strings.           
            string[] arr1= { "Hello","Word"};            
           
            var valueArr = from value in arr1
                          where value.ToString() == arr1.ToString()                         
                          select value;
            
            foreach (string str in arr1)
            {                  
            Console.Write("\nLINQ : Print the lenght of the strings in the array : " + str.Length );
            }
            Console.Write("\n------------------------------------------------------\n");
            
           
            //2.- Write a program in C# to print the size of a file in bytes in a directory using LINQ.
            string[] dirfiles = Directory.GetFiles("C:/Test");
            
            var valuefile = from value in dirfiles
                            where value.Contains(dirfiles.ToString())
                           select value;
            foreach (string fileSize in dirfiles)
            {
                 long size = new FileInfo(fileSize).Length;               
                Console.Write("\nLINQ : Calculate the Size of File : "+size );               
            }
            Console.Write("\n------------------------------------\n");

           
            //3.- Write a program in C# to shows how the three parts of a query operation execute.
            // The first part is Data source.
            int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // 1.- LINQ Query, first a result variable  then FROM clause followed by range: from value in n1
                              //from value as range in a collection of iquery as n1.
            var valueResult = from value in n1
                              // 2.- LINQ Query WHERE query followed by condition: where value > 2 && value < 8
                              where value > 2 && value < 8
                              // 2.- LINQ Query SELECT query to select each result of condition: where value > 2 && value < 8
                              select value;
            foreach (int varArr in valueResult)
            {
                Console.Write("\nBasic structure of LINQ : "+ varArr);
            }
            Console.Write("\n---------------------------");

            // 4.- Write a program in C# to display the name of the days of a week.
            string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            var valueArr2 = from value in dayWeek
                            where value.ToString() == dayWeek.ToString()
                           select value;

            foreach (string str in dayWeek)
            {
                Console.Write("\nLINQ : Display the name of the days of a week : " + str.ToString());
            }

            //Console.Write("\nLINQ : Display the name of the days of a week : ");
            Console.Write("\n------------------------------------------------\n");
           

            //5.- Write a program in C# to print the number and its square from an array.
            var arr2 = new[] { 3, 9, 2, 8, 6, 5 };

            var valueResult2 = from value in arr2
                               where value == arr2.Length
                               select value;
            foreach (int varArr in arr2)
            {
                int var = varArr;
                Console.Write("\nLINQ : Print the number and its square from an array: Number : " + varArr + "  The Square Of The Number : "+var*var );
            }            
            Console.Write("\n------------------------------------------------------------------------\n");

            Console.ReadLine();
        }       
    }
}
