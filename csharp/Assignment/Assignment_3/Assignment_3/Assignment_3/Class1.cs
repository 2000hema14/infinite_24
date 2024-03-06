using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{   //2.
    class Class1
    {
        static void Main()
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            Console.WriteLine("Enter the letter to count:");
            char letter = Console.ReadLine()[0]; 

            int count = input.Count(c => c == letter);
            Console.WriteLine($"The letter '{letter}' occurs {count} times in the string.");
            Console.ReadLine();
        }
    }
}