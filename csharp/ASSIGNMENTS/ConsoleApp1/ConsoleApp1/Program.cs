using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Equalno()
        {
            Console.Write("1st num: ");
            int n1 = int.Parse(Console.ReadLine());
            Console.Write("2st num: ");
            int n2 = int.Parse(Console.ReadLine());

            if (n1==n2)
            {
                Console.WriteLine($"{n1} and {n2} are equal.");
            }
            else
            {
                Console.WriteLine($"{n1} and {n2} are not equal.");
            }

        }
        static void PositiveNgative()
        {
            Console.Write("Enter a num:");
            int num = int.Parse(Console.ReadLine());
            if (num > 0)
            {
                Console.WriteLine($"{num} is positive");
            }
            else if (num<0)
            {
                Console.WriteLine("num is negative");
            }
        }
        static void Operations()
        {
            Console.Write("First num:");
            int n1 = int.Parse(Console.ReadLine());
            Console.Write("Input Operation:");
            char operation = char.Parse(Console.ReadLine());
            Console.Write("second num:");
            int n2 = int.Parse(Console.ReadLine());
            if (operation=='+')
            {
                Console.WriteLine($"{n1}+{n2}={n1 + n2}");
            }
            else if (operation == '-')
            {
                Console.WriteLine($"{n1}-{n2}={n1 - n2}");
            }
            else if (operation=='*')
            {
                Console.WriteLine($"{n1}*{n2}={n1 * n2}");
            }
            else if (operation=='/')
            {
                if (n2!=0)
                {
                    Console.WriteLine($"{n1}/{n2}={n1 / n2}");
                }
                else
                {
                    Console.WriteLine("division by zero is not allowed");
                }
            }

        }
        static void Multiplication()
        {
            Console.Write("Enter the number");
            int num = int.Parse(Console.ReadLine());
            for (int i=0;i<11;i++)
            {
                Console.WriteLine($"{num}*{i}={num * i}");

            }
        }
        static void Sumtriple()
        {
            Console.Write("Enter the n1:");
            int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter n2:");
            int n2 = int.Parse(Console.ReadLine());
            int sum = n1 + n2;
            if (n1==n2)
            {
                Console.WriteLine($"{sum * 3}");
            }
            
        }
            static void Main(string[] args)
        {
            Console.WriteLine("---Equalornot----");
            Equalno();
            Console.WriteLine("-----PositiveNegative------");
            PositiveNgative();
            Console.WriteLine("---operations----");
            Operations();
            Console.WriteLine("---multiplication Table-----");
            Multiplication();
            Console.WriteLine("----Sumtriple-----");
            Sumtriple();
            Console.Read();
        }
    }
}
