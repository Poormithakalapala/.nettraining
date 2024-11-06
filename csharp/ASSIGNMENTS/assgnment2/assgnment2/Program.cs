using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assgnment2
{
    class Program
    {
        static void Swapnum()
        {
            int num1, num2, temp;
            Console.Write("Enter n1: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter n2: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nBefore swapping: num1={num1},num2={num2}");
            temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine($"\nAfter swapping: num1={num1},num2={num2}");
        }
        static void SepBlank()
        {
            int num;
            Console.Write("Enter the digit: ");
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} {0} {0} {0}",num);
            Console.WriteLine("{0}{0}{0}{0}", num);
            Console.WriteLine("{0} {0} {0} {0}", num);
            Console.WriteLine("{0}{0}{0}{0}", num);
        }
        static void Days()
        {
            Console.Write("Enter a day num: ");
            int daynum = Convert.ToInt32(Console.ReadLine());
            string dayName;
            switch (daynum)
            {
                case 0:
                    dayName = "sunday";
                    break;
                case 1:
                    dayName = "Monday";
                    break;
                case 2:
                    dayName = "Tuesday";
                    break;
                case 3:
                    dayName = "Wednesday";
                        break;
                case 4:
                    dayName = "Thusday";
                    break;
                case 5:
                    dayName = "Friday";
                    break;
                case 6:
                    dayName = "Saturday";
                    break;
                default:
                    dayName = "Invalid";
                    break;
            }
            Console.WriteLine($"day: {dayName}");
        }
        static void AvgMinMax()
        {
            int[] num = { 5, 10, 15, 20, 25 };
            double avg = num.Average();
            int min = num.Min();
            int max = num.Max();

            Console.WriteLine("array elements: " + string.Join(",", num));
            Console.WriteLine($"Avg val of an array elements: {avg}");
            Console.WriteLine($"Min value of an array:{min}, Max value of an array:{max}");
        }
        static void TenMarks()
        {
            int[] marks = new int[10];
            Console.WriteLine("Enter 10 marks: ");
            for (int i=0; i<marks.Length; i++)
            {
                Console.Write($"Mark {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            int total = marks.Sum();
            double average = marks.Average();
            int min = marks.Min();
            int max = marks.Max();

            Console.WriteLine($"\nTotal Marks: {total}");
            Console.WriteLine($"Average Marks: {average}");
            Console.WriteLine($"Minimum Marks:{min}");
            Console.WriteLine($"Maximum Marks: {max}");
            Console.WriteLine("\nMarks in Asce");
        }
        static void TenmarksAscDes()
        {
            int[] marks = new int[10];
            Console.WriteLine("Enter 10 marks: ");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write("Enter mark {0}: ", i + 1);
                marks[i] = int.Parse(Console.ReadLine());
            }
            int total = marks.Sum();
            double average = marks.Average();
            int min = marks.Min();
            int max = marks.Max();

            Console.WriteLine("\nResults:");
            Console.WriteLine("Total marks: " + total);
            Console.WriteLine("Average marks: " + average);
            Console.WriteLine("Minimum marks: " + min);
            Console.WriteLine("Maximum marks: " + max);
            Console.WriteLine("\nMarks in Asc:");
            Array.Sort(marks);
            foreach(int mark in marks)
            {
                Console.Write(mark + " ");
            }
            Console.WriteLine("\n\nMarks in desc:");
            Array.Reverse(marks);
            foreach (int mark in marks)
            {
                Console.Write(mark + " ");
            }
        }
        static void CopyArray()
        {
            int[] sourceArray = { 1, 2, 3, 4, 5 };
            int[] destinationArray = new int[sourceArray.Length];

            for (int i=0;i<sourceArray.Length; i++)
            {
                destinationArray[i] = sourceArray[i];
            }
            Console.WriteLine("Elements of destination array:");
            foreach(int element in destinationArray)
            {
                Console.Write(element + " ");
            }
        }
        static void Main(String[] args)
        {
            Console.WriteLine("-------Swap numbers------");
            Swapnum();
            Console.WriteLine("----SepBlank----");
            SepBlank();
            Console.WriteLine("---Days---");
            Days();
            Console.WriteLine("----ArrayAvgMinMax-----");
            AvgMinMax();
            Console.WriteLine("----TenMarksAscDesc-----");
            TenmarksAscDes();
            Console.WriteLine("----CopyArray---");
            CopyArray();
            Console.Read();
        }
    }
}
