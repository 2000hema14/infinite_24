using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class sum_integer
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("enter the first number:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the second number:");
            int num2 = int.Parse(Console.ReadLine());
            int result = compute(num1, num2);
            Console.WriteLine("result:" + result);
            Console.ReadLine();
        }


    }
}
