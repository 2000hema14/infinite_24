using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class array_b
    {
        public static void Main(string[] args)
        {

            int[] marks = new int[10];


            Console.WriteLine("Enter 10 marks:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Enter mark {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Displaying total
            int total = marks.Sum();
            Console.WriteLine($"Total: {total}");

            //Displaying average
            double average = marks.Average();
            Console.WriteLine($"Average: {average}");

            // Displaying maximum marks
            int maxMarks = marks.Max();
            Console.WriteLine($"Maximum Marks: {maxMarks}");

            // Displaying minimum marks
            int minMarks = marks.Min();
            Console.WriteLine($"Minimum Marks: {minMarks}");

            // Displaying marks in ascending order
            Console.WriteLine("Marks in Ascending Order:");
            int[] ascendingOrder = marks.OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join(", ", ascendingOrder));

            // Displaying marks in descending order
            Console.WriteLine("Marks in Descending Order:");
            int[] descendingOrder = marks.OrderByDescending(x => x).ToArray();
            Console.WriteLine(string.Join(", ", descendingOrder));
            Console.ReadLine();

        }
    }
}
