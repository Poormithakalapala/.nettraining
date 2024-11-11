using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Scholarship
    {
        public double Merit(int marks, double fees)
        {
            double scholarshipAmount = 0.0;

            if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = 0.20 * fees;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = 0.30 * fees;
            }
            else if (marks > 90)
            {
                scholarshipAmount = 0.50 * fees;
            }

            return scholarshipAmount;
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter your marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your fees: ");
            double fees = Convert.ToDouble(Console.ReadLine());
            Scholarship a = new Scholarship();
            double scholarshipAmount = a.Merit(marks, fees);
            Console.WriteLine("Scholarship Amount: " + scholarshipAmount);
            Console.ReadLine();
        }
    }
}
