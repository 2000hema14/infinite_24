using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    interface IStudent
    {
        int StudentId { get; set; }
        string Name { get; set; }

        void ShowDetails();
    }

    class Dayscholar : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine($"Dayscholar - Student ID: {StudentId}, Name: {Name}");
        }
    }

    class Resident : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine($"Resident - Student ID: {StudentId}, Name: {Name}");
        }
    }

    class StudentDetails
    {
        static void Main()
        {
            Console.WriteLine("Enter Dayscholar Details:");
            Console.Write("Student ID: ");
            int dayscholarId = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string dayscholarName = Console.ReadLine();
            IStudent dayscholar = new Dayscholar { StudentId = dayscholarId, Name = dayscholarName };

            Console.WriteLine("\nEnter Resident Details:");
            Console.Write("Student ID: ");
            int residentId = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string residentName = Console.ReadLine();
            IStudent resident = new Resident { StudentId = residentId, Name = residentName };

            Console.WriteLine("\nStudent Details:");
            dayscholar.ShowDetails();
            resident.ShowDetails();
            Console.Read();
        }
        
    }
}
