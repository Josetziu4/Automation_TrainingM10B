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
            #region Exercise 1 String Lenght from an Array
            //This code prints the lenght of a string specifying its position
            string[] arrStrExercise1 = new string[] {"abc","bcde","fghijk"};
            Console.Write("\nLINQ : Print the lenght of the strings in the array : ");
            Console.Write("\n------------------------------------------------------\n");
            for (int x = 0; x < arrStrExercise1.Length; x++)
            {
                Console.WriteLine("The String Lenght of " + arrStrExercise1[x] + " is {0} ", arrStrExercise1[x].Length);
            }
            #endregion
            #region Exercise 2 Size if a File Using LINQ
            //Directory of Files
            FileInfo objFileInfo;
            string[] strDirFiles = Directory.GetFiles("C:/LINQFiles/");
            Console.Write("\nLINQ : Calculate the Size of File : ");
            Console.Write("\n------------------------------------\n");
            //Write Your code
            string[] arrStrFileNames = new string[] { "abcd.txt", "simple_file.txt", "xyz.txt" };
            int j = -1; //This allows to start with the value ZERO in the Do while statement
            for (int i = 0; i < arrStrFileNames.Length; i++)
            {
                do
                {
                    j++;
                    objFileInfo = new FileInfo(strDirFiles[j]);
                    if (objFileInfo.Name == arrStrFileNames[i])
                    break;
                } while (false);
                Console.WriteLine("The file "+ arrStrFileNames[i] + " size is {0} Bytes", objFileInfo.Length);
            }
            //LINQ queries.
            var nFilesSizes = from vSize in strDirFiles select vSize;
            foreach (string vSize in nFilesSizes)
            {
                Console.Write("{0} ", vSize);
                Console.Write("\n");
            }
            #endregion
            #region Exercise 3 three parts of a query 
            //1-DATA SOURCE
            int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.Write("\nBasic structure of LINQ : ");
            Console.Write("\n---------------------------");
            //2-QUERY-REQUEST
            var nQuery = from vNum in n1 select vNum;
            //3-QUERY EXECUTION
            Console.Write("\nNumbers: \n");
            foreach (int vNum in nQuery)
            {
                Console.Write("{0} ", vNum);
            }
            Console.Write("\n\n");
            #endregion
            #region Exercise 4 display the name of the days of a week
            string[] arrStrDayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            Console.Write("\nLINQ : Display the name of the days of a week : ");
            Console.Write("\n------------------------------------------------\n");
            var days = from WeekDay in arrStrDayWeek select WeekDay;
            foreach (var WeekDay in days)
            {
            Console.WriteLine(WeekDay);
            }
            #endregion
            #region Exercise 5 print the number and its square
            var arr2 = new[] { 3, 9, 2, 8, 6, 5 };
            Console.Write("\nLINQ : Print the number and its square from an array: ");
            Console.Write("\n------------------------------------------------------------------------\n");
            //Write Your code
            var sqNum = from int Number in arr2
            let SqrNo = Number * Number
            select new { Number, SqrNo };
            foreach (var a in sqNum)
            Console.WriteLine(a);
            Console.ReadLine();
            #endregion
        }
    }
}
