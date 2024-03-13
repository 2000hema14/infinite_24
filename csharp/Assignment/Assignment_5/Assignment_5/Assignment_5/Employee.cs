using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Employee
    {
        public int Empid { get; }
        public string Empname { get; }
        public float Salary { get; }

        public Employee(int empid, string empname, float salary)
        {
            Empid = empid;
            Empname = empname;
            Salary = salary;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Employee ID: {Empid}, Name: {Empname}, Salary: {Salary}");
        }
    }

    class ParttimeEmployee : Employee
    {
        public float Wages { get; }

        public ParttimeEmployee(int empid, string empname, float salary, float wages) : base(empid, empname, salary)
        {
            Wages = wages;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Wages: {Wages}");
        }
    }

    class Program
    {
        static void Main()
        {
           
            Console.WriteLine("Enterthe details of Full-time Employee:");
            Console.Write("Employee ID: ");
            int empid1 = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name1 = Console.ReadLine();
            Console.Write("Salary: ");
            float salary1 = float.Parse(Console.ReadLine());
            Employee emp1 = new Employee(empid1, name1, salary1);

            Console.WriteLine("\nEnter the details of the Part-time Employee:");
            Console.Write("Employee ID: ");
            int empid2 = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name2 = Console.ReadLine();
            Console.Write("Salary: ");
            float salary2 = float.Parse(Console.ReadLine());
            Console.Write("Wages: ");
            float wages2 = float.Parse(Console.ReadLine());
            ParttimeEmployee emp2 = new ParttimeEmployee(empid2, name2, salary2, wages2);

            Console.WriteLine("\nFull-time Employee:");
            emp1.Display();

            Console.WriteLine("\nPart-time Employee:");
            emp2.Display();
            Console.Read();
            
        }
    }
}


