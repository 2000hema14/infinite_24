using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3
{
    delegate int Calculator(int a, int b);

    class Arthimatic_op
    {
        static void Main()
        {
            Calculator add = (a, b) => a + b;
            Calculator subtract = (a, b) => a - b;
            Calculator multiply = (a, b) => a * b;

            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter two numbers:");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Addition: {add(num1, num2)}");
                    break;
                case 2:
                    Console.WriteLine($"Subtraction: {subtract(num1, num2)}");
                    break;
                case 3:
                    Console.WriteLine($"Multiplication: {multiply(num1, num2)}");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
                   
            }
            Console.ReadKey();
        }
    }
}

