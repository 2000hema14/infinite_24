using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("enter the first integer:");
            //int num1 = int.Parse(Console.ReadLine());

            //Console.WriteLine("enter the second integer:");
            //int num2 = int.Parse(Console.ReadLine());

            //if (num1 == num2)
            //{
            //    Console.WriteLine("the two integers are equal");

            //}

            //else
            //{
            //    Console.WriteLine("the two integers are not equal");
            //}
            //Console.ReadKey();

            // to check the given number is positive or negative.

            //Console.WriteLine("enter a number:");
            //int number = int.Parse(Console.ReadLine());
            //if (number > 0)
            //{
            //    Console.WriteLine("the number is positive");

            //}
            //else if (number < 0)
            //{
            //    Console.WriteLine("the number is negative ");

            //}
            //else
            //{
            //    Console.WriteLine("the number is zero");

            //}
            //Console.ReadLine();

            //3.two number performing arthimatic operations.
            int Num1, Num2, result;
            char option;
            Console.Write("Enter the First Number : ");
            Num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Second Number : ");
            Num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.Write("Enter the Operation you want to perform : ");
            option = Convert.ToChar(Console.ReadLine());
            switch (option)
            {
                case '1':
                    result = Num1 + Num2;
                    Console.WriteLine("The result of Addition is : {0}", result);
                    break;
                case '2':
                    result = Num1 - Num2;
                    Console.WriteLine("The result of Subtraction is : {0}", result);
                    break;
                case '3':
                    result = Num1 * Num2;
                    Console.WriteLine("The result of Multiplication is : {0}", result);
                    break;
                case '4':
                    result = Num1 / Num2;
                    Console.WriteLine("The result of Division is : {0}", result);
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            Console.ReadLine();


            //4.Multiplication table.

            //Console.WriteLine("enter the first number:");
            //int number = int.Parse(Console.ReadLine());
            //Console.WriteLine($"multipication table for {number}:");
            //for (int i = 1; i <= 10; i++)
            //{
            //    int result = number * i;
            //    Console.WriteLine($"the {number} * {i} = {result}");

            //}
            //Console.ReadLine();

            //5.Return triple of a given sum

            //Console.WriteLine("enter the first number:");
            //int num1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("enter the second number:");
            //int num2 = int.Parse(Console.ReadLine());
            //int result = computesum(num1, num2);
            //Console.WriteLine("result:" + result);
            //Console.ReadLine();

            //6.display the name of the day for the given number.

            int dayNumber = Convert.ToInt32(Console.ReadLine());
            switch (dayNumber)
            {
                case 0:
                    Console.WriteLine("Sunday");
                    break;
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                default:
                    Console.WriteLine("The  dayNumber is invalid");
                    break;
            }
            Console.ReadLine();



            //Array 1.

            //Console.WriteLine("Enter the size of the array:");
            //                        int size = int.Parse(Console.ReadLine());

            //                        // Create an array with the specified size
            //                        int[] numbers = new int[size];

            //                        // Input values into the array
            //                        Console.WriteLine($"Enter {size} integer values:");

            //                        for (int i = 0; i < size; i++)
            //                        {
            //                            Console.Write($"Element {i + 1}: ");
            //                            numbers[i] = int.Parse(Console.ReadLine());
            //                        }
            //2.

            //int[] marks = new int[10];


            //Console.WriteLine("Enter 10 marks:");
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.Write($"Enter mark {i + 1}: ");
            //    marks[i] = Convert.ToInt32(Console.ReadLine());
            //}

            ////Displaying total
            //int total = marks.Sum();
            //Console.WriteLine($"Total: {total}");

            ////Displaying average
            //double average = marks.Average();
            //Console.WriteLine($"Average: {average}");

            //// Displaying maximum marks
            //int maxMarks = marks.Max();
            //Console.WriteLine($"Maximum Marks: {maxMarks}");

            //// Displaying minimum marks
            //int minMarks = marks.Min();
            //Console.WriteLine($"Minimum Marks: {minMarks}");

            //// Displaying marks in ascending order
            //Console.WriteLine("Marks in Ascending Order:");
            //int[] ascendingOrder = marks.OrderBy(x => x).ToArray();
            //Console.WriteLine(string.Join(", ", ascendingOrder));

            //// Displaying marks in descending order
            //Console.WriteLine("Marks in Descending Order:");
            //int[] descendingOrder = marks.OrderByDescending(x => x).ToArray();
            //Console.WriteLine(string.Join(", ", descendingOrder));
            //Console.ReadLine();



            //string
            //1.
            // Initializing the source array
            //int[] sourceArray = { 1, 2, 3, 4, 5 };

            //// Creating a destination array with the same length as the source array
            //int[] destinationArray = new int[sourceArray.Length];

            //// Copying elements from the source array to the destination array
            //for (int i = 0; i < sourceArray.Length; i++)
            //{
            //    destinationArray[i] = sourceArray[i];
            //}

            //// Displaying the elements of the destination array
            //Console.WriteLine("Elements in the destination array:");
            //foreach (int element in destinationArray)
            //{
            //    Console.Write($"{element} ");
            //}
            //Console.ReadLine();
            //2.
            // string length finder
            //        Console.Write("Enter a word: ");
            //        string rinput = Console.ReadLine();

            //        int wordLength = rinput.Length;

            //        Console.WriteLine($"Length of the word '{rinput}' is: {wordLength}");
            //        Console.ReadLine();

            //3.
            Console.Write("Enter a String : ");
            string originalString = Console.ReadLine();
            string reverseString = string.Empty;
            for (int i = originalString.Length - 1; i >= 0; i--)
            {
                reverseString += originalString[i];
            }
            Console.Write($"Reverse String is : {reverseString} ");
            Console.ReadLine();
        }
    }
































