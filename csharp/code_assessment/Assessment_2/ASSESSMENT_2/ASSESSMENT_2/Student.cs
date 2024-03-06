using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSESSMENT_2
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        public abstract bool IsPassed(double grade);
    }

    class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    internal class Students
    {
        static void Main(string[] agrs)
        {
            // Creating an instance of Undergraduate
            Student undergraduate = new Undergraduate
            {
                Name = "Rithika",
                StudentId = 543021,
                Grade = 75
            };

            // Creating an instance of Graduate
            Student graduate = new Graduate
            {
                Name = "Hema",
                StudentId = 109876,
                Grade = 95
            };

            // Checking if the students passed
            bool passedUndergraduate = undergraduate.IsPassed(undergraduate.Grade);
            bool passedGraduate = graduate.IsPassed(graduate.Grade);

            Console.WriteLine($"Undergraduate student {undergraduate.Name} with ID {undergraduate.StudentId} {(passedUndergraduate ? "passed" : "FAIL")}");
            Console.WriteLine($"Graduate student {graduate.Name} with ID {graduate.StudentId} {(passedGraduate ? "PASS" : "FAIL")}");

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}