using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_Assessment
{
    class Exchange_two_char
    {
        public static void Main(string[] agrs)
        {
            Console.WriteLine("Enter a string:");
            string inputString = Console.ReadLine();

            string resultString = ExchangeFirstAndLastCharacters(inputString);

            Console.WriteLine("String result after exchanging first and the last characters: {0}", resultString);
            Console.ReadLine();

        }


        static string ExchangeFirstAndLastCharacters(string input)
        {
            if (input.Length < 2)
            {
                Console.WriteLine("the string shuld contain atleast two char");
                return input;

            }
            char[] charArray = input.ToCharArray();
            char temp = charArray[0];
            charArray[0] = charArray[input.Length - 1];
            charArray[input.Length - 1] = temp;
            return new string(charArray);
        }
    }
}
