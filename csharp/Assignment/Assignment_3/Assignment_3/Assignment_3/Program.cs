using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first name:");
            string firstNameInput = Console.ReadLine();

            Console.WriteLine("Enter last name:");
            string lastNameInput = Console.ReadLine();

            Display(firstNameInput, lastNameInput);
        }

        static void Display(string firstName, string lastName)
        {
            Console.WriteLine(firstName.ToUpper());
            Console.WriteLine(lastName.ToUpper());
            Console.ReadLine();

        }
    }
}