using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class array_a
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array:");
            int size = int.Parse(Console.ReadLine());

            // Create an array with the specified size
            int[] numbers = new int[size];

            // Input values into the array
            Console.WriteLine($"Enter {size} integer values:");

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Element {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
