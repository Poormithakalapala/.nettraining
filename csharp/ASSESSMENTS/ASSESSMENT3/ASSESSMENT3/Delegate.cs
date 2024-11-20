using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSESSMENT3
{
    class Delegate
    {
        public delegate int CalculatorOperation(int num1, int num2);

        
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static void Operation(CalculatorOperation operation, int num1, int num2)
        {
            int result = operation(num1, num2);
            Console.WriteLine($"Result: {result}");
        }

        static void Main()
        {
            Console.WriteLine("Enter the first number:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("\nChoose an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Addition:{num1}+{num2}={num1+num2}");
                    Operation(Add, num1, num2);
                    break;
                case 2:
                    Console.WriteLine($"Subtraction:{num1}-{num2}={num1-num2}");
                    Operation(Subtract, num1, num2);
                    break;
                case 3:
                    Console.WriteLine($"Multiplication:{num1}*{num2}={num1*num2}");
                    Operation(Multiply, num1, num2);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please select 1, 2, or 3.");
                    break;
            }
            Console.Read();
        }
    }
}
