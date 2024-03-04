using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class string_2
    {
        public static void Main(string[] args)
        {
                    Console.Write("Enter a word: ");
            string rinput = Console.ReadLine();

            int wordLength = rinput.Length;

            Console.WriteLine($"Length of the word '{rinput}' is: {wordLength}");
            Console.ReadLine();
        }
    }
}
