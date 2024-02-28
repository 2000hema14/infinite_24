using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        private static string largest;

        static void Main(string[] args)
        {
            //1.
            //    Console.WriteLine("Enter a string:");
            //    string inputString = Console.ReadLine();

            //    Console.WriteLine("Enter a position to remove (  string length 0 - 1):");
            //    int position = int.Parse(Console.ReadLine());

            //    if (position < 0 || position >= inputString.Length)
            //    {
            //        Console.WriteLine("Invalid position (string length 0 - 1).");
            //    }
            //    else
            //    {
            //        string resultString = RemoveTheCharaAtposition(inputString, position);
            //        Console.WriteLine("String after removing char at position {0}: {1}", position, resultString);
            //    }
            //    Console.ReadLine();
            //}

            //static string RemoveCharaAtPosition(string input, int position)
            //{
            //    return input.Remove(postion, 1);
            //2.
            //            Console.WriteLine("Enter a string:");
            //            string inputString = Console.ReadLine();

            //            string resultString = ExchangeFirstAndLastCharacters(inputString);

            //            Console.WriteLine("String result after exchanging first and the last characters: {0}", resultString);
            //            Console.ReadLine();

            //        }


            //        static string ExchangeFirstAndLastCharacters(string input)
            //        {
            //            if (input.Length < 2)
            //            {
            //                Console.WriteLine("the string shuld contain atleast two char");
            //                return input;

            //            }
            //            char[] charArray = input.ToCharArray();
            //            char temp = charArray[0];
            //            charArray[0] = charArray[input.Length - 1];
            //            charArray[input.Length - 1] = temp;
            //            return new string(charArray);
            //            //3.
            Console.Write("Enter the 1st num: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the 2nd num: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.Write("Enter the 3rd num: ");
            int num3 = int.Parse(Console.ReadLine());
            int largestNumber = FindLargestNumber(num1, num2, num3);

            Console.WriteLine("The largest number of these {0}, {1}, and {2} is: {3}", num1, num2, num3, largestNumber);
            Console.ReadLine();
        }

        static int FindLargestNumber(int a, int b, int c)
        {
            int max = a;

            if (b > max)
            {
                max = b;
            }

            if (c > max)
            {
                max = c;
            }

            return max;
        }
    }
}













































