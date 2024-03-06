using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    using System;

    class Doctor
    {
        private int RegNo;
        private string Name;
        private double FeesCharged;


        public void SetValues(int regnNo, string name, double feesCharged)
        {
            RegNo = regnNo;
            Name = name;
            FeesCharged = feesCharged;
        }


        public void DisplayValues()
        {
            Console.WriteLine($"Registration Number: {RegNo}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Fees Charged: {FeesCharged}");
        }
    }

    class Question5
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor();


            doctor.SetValues(1034321, "Dr.hemalatha",200.00);


            doctor.DisplayValues();

            Console.ReadLine();
        }
    }
}