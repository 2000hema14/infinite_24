using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class string_1
    {
        public static void Main(string[] args)
        {
            int[] sourceArray = { 1, 2, 3, 4, 5 };

            // Creating a destination array 
            int[] destinationArray = new int[sourceArray.Length];

            // Copying elements from  source array to  destination array
            for (int i = 0; i < sourceArray.Length; i++)
            {
                destinationArray[i] = sourceArray[i];
            }

            // Displaying the elements of the array
            Console.WriteLine("Elements in the destination array:");
            foreach (int element in destinationArray)
            {
                Console.Write($"{element} ");
            }
            Console.ReadLine();
        }
    }
}
