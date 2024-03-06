using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Scholarship
    {
        public double Merit(int marks, double fees)
        {
            if (marks < 0 || marks > 100)
            {
                throw new ArgumentException("Invalid marks. Marks should be between 0 and 100.");
            }

            double scholarshipAmount = 0;

            if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = 0.2 * fees;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = 0.3 * fees;
            }
            else if (marks > 90)
            {
                scholarshipAmount = 0.5 * fees;
            }

            return scholarshipAmount;
        }
    }

    class Amount
    {
        static void Main()
        {
            try
            {
                Scholarship scholarship = new Scholarship();
                int marks = 65;
                double fees = 100000;
                double scholarshipAmount = scholarship.Merit(marks, fees);

                Console.WriteLine($"Scholarship Amount: {scholarshipAmount}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: { ex.Message}");
               
            }
            Console.ReadLine();
        }
    }
}