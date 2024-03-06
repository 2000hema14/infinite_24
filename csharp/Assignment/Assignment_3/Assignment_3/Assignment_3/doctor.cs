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
        private int RegnNo;
        private string Name;
        private double FeesCharged;


        public void SetValues(int regnNo, string name, double feesCharged)
        {
            RegnNo = regnNo;
            Name = name;
            FeesCharged = feesCharged;
        }


        public void DisplayValues()
        {
            Console.WriteLine($"Registration Number: {RegnNo}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Fees Charged: {FeesCharged}");
        }
    }

    class Qa5
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor();


            doctor.SetValues(109876, "Dr.Hemalatha", 250.50);


            doctor.DisplayValues();

            Console.ReadLine();
        }
    }
}