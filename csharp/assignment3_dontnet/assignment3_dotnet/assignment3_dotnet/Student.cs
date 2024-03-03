using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3_dotnet
{
    class Student
    {
        // Data members
        public string RollNo { get; private set; }
        public string Name { get; private set; }
        public string Class { get; private set; }
        public int Semester { get; private set; }
        public string Branch { get; private set; }
        private int[] marks = new int[5]; // Marks of 5 subjects

        // Constructor
        public Student(string rollNo, string name, string studentClass, int semester, string branch)
        {
            RollNo = rollNo;
            Name = name;
            Class = studentClass;
            Semester = semester;
            Branch = branch;
        }

        // Method to input marks for 5 subjects
        public void GetMarks()
        {
            Console.WriteLine("Enter marks for 5 subjects:");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write($"Subject {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Method to calculate and display average marks
        public void DisplayResult()
        {
            double sum = 0;
            foreach (int mark in marks)
            {
                sum += mark;
            }

            double average = sum / marks.Length; // Calculate average marks

            Console.WriteLine($"Average marks: {average}");

            if (average >= 50) // If average marks is 50 or above
            {
                Console.WriteLine("Result: Passed");
            }
            else // If average marks is less than 50
            {
                Console.WriteLine("Result: Failed");
            }
        }
        public void DisplayData()
        {
            Console.WriteLine($"Roll No: {RollNo}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Semester: {Semester}");
            Console.WriteLine($"Branch: {Branch}");
            Console.WriteLine("Marks:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Subject {i + 1}: {marks[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a Student object
            Student student = new Student("2024001", "Hema", "12th", 2, "Biology");

            // Input marks for 5 subjects
            student.GetMarks();

            // Display student data and result
            student.DisplayData();
            Console.WriteLine();
            student.DisplayResult();
            Console.ReadKey();
        }
    }

}




