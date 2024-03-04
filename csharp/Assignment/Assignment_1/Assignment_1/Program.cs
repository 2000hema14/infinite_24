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
            Console.WriteLine("enter the first integer:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("enter the second integer:");
            int num2 = int.Parse(Console.ReadLine());

            if (num1 == num2)
            {
                Console.WriteLine("the two integers are equal");

            }

            else
            {
                Console.WriteLine("the two integers are not equal");
            }
            Console.ReadKey();
        }
    }
}
