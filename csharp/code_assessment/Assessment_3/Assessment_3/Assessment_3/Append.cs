using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3
{
        class Append
        {
            static void Main()
            {
                string filePath = "sample.txt";
                string textToAppend = "MY ASSESSMENT 3";

                try
                {
                   
                    using (StreamWriter sw = new System.IO.StreamWriter(filePath, true))
                    {
                        sw.WriteLine(textToAppend);
                    }

                    Console.WriteLine("The  text has been append.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }

                Console.ReadLine();
            }
        }
    }