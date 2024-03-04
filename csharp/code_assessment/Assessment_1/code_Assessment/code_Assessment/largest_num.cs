using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_Assessment
{
    class largest_num
    {
        public static void Main(string[] agrs)
        {
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
