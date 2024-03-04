using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_Assessment
{
    class Program
    {
        private static int postion;

        static void Main(string[] args)
        {
           // 1.
                Console.WriteLine("Enter a string:");
            string inputString = Console.ReadLine();

            Console.WriteLine("Enter a position to remove (  string length 0 - 1):");
            int position = int.Parse(Console.ReadLine());

            if (position < 0 || position >= inputString.Length)
            {
                Console.WriteLine("Invalid position (string length 0 - 1).");
            }
            else
            {
                string resultString = RemoveTheCharaAtposition(inputString, position);
                Console.WriteLine("String after removing char at position {0}: {1}", position, resultString);
            }
            Console.ReadLine();
        }

        private static string RemoveTheCharaAtposition(string inputString, int position)
        {
            throw new NotImplementedException();
        }

        static string RemoveCharaAtPosition(string input, int position)
        {
            return input.Remove(postion, 1);
        }
    }
}
