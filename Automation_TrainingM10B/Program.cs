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

            string[] arr1 = { "Print", "the", "lenght", "of", "the", "strings", "in", "the", "array" };
            int n, i;
            
            Console.Write("\nExercise One :\n");
            Exercise_One();     

            Console.Write("\nExercise Two :\n");
            Exercise_Two();

            Console.Write("\nExercise Three :\n");
            Exercise_Three();

            Console.Write("\nExercise Four :\n");
            Exercise_Four();

            Console.Write("\nExercise Five :\n");
            Exercise_Five();

            void Exercise_One()
            {
                var elementsFound = from element in arr1
                                  where element.Length > 0
                                  select element;

                Console.Write("\nLINQ : Print the lenght of the strings in the array : ");
                Console.Write("\n------------------------------------------------------\n");
                foreach (string singleElement in elementsFound)
                {
                    Console.WriteLine($"The element '{singleElement}' into the list has: {singleElement.Length} characters.");
                }
                Console.ReadLine();
            }

            void Exercise_Two()
            {
                Console.Write("\nLINQ : Calculate the Size of File : ");
                Console.Write("\n------------------------------------\n");

                if (!Directory.Exists("C:/Test"))
                {
                    Directory.CreateDirectory("C:/Test");
                }

                string[] dirfiles = Directory.GetFiles("C:/Test");

                var filesInFolder = from fileFound in dirfiles
                                    select fileFound;

                if (filesInFolder.Count() > 0)
                {
                    foreach (string file in filesInFolder)
                    {
                        Console.WriteLine($"The following file '{file}' has a size of: {file.Length} bytes");
                    }
                }
                else 
                    Console.WriteLine("There are no files on the directory. :(");

                Console.ReadLine();
            }

            void Exercise_Three()
            {
                // The first part is Data source.
                int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Console.Write("\nBasic structure of LINQ : ");
                Console.Write("\n---------------------------\n");

                var intElementsFound = n1.Where(x => x % 2 == 1);
                var orderDescending = intElementsFound.OrderByDescending(x => x);

                Console.WriteLine("Following List is of unpair numbers ordered desending from the list given:");
                foreach (int number in orderDescending)
                {
                    Console.WriteLine(number);
                }


                Console.ReadLine();
            }

            void Exercise_Four()
            {
                string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

                Console.Write("\nLINQ : Display the name of the days of a week : ");
                Console.Write("\n------------------------------------------------\n");

                var daysOfTheWeek = from day in dayWeek
                                    select day;
                int num = 1;
                foreach (string singleDay in daysOfTheWeek)
                {  
                    Console.WriteLine($"{num}.- {singleDay}");
                    num++;
                }
                Console.ReadLine();
            }

            void Exercise_Five()
            {
                var arr2 = new[] { 3, 9, 2, 8, 6, 5 };
                Console.Write("\nLINQ : Print the number and its square from an array: ");
                Console.Write("\n------------------------------------------------------------------------\n");

                var numbers = from numberArr in arr2
                              select numberArr;

                Console.WriteLine("Number || Square");
                double dblSquare;
                foreach (int singleNumber in numbers)
                {
                    dblSquare = singleNumber * singleNumber;
                    Console.WriteLine($"{singleNumber} || {dblSquare}");
                    
                }

                Console.ReadLine();
            }

        }
    }
}