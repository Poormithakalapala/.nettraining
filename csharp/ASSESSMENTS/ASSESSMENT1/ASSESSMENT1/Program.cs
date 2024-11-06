using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSESSMENT1
{
    class Program
    {
        static void LargestNum()
        {
            Console.WriteLine("Enter num1:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter num2:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter num3:");
            int num3 = Convert.ToInt32(Console.ReadLine());
            if (num1 >= num2 && num1 >= num3)
            {
                Console.WriteLine(num1);
            }
            else if ( num2>=num1 && num2 >= num3)
            {
                Console.WriteLine(num2);
            }
            else
            {
                Console.WriteLine(num3);
            }

        }
        static void RemoveCharAtPosition()
        {
            Console.WriteLine("Enter a string:");
            string inputString = Console.ReadLine();

            Console.WriteLine("Enter the position to remove:");
            int position = Convert.ToInt32(Console.ReadLine());
            if (position >= 0 && position < inputString.Length)
            {
                string result = inputString.Substring(0, position) + inputString.Substring(position + 1);
                Console.WriteLine($"String after removing character at position {position}: {result}");
            }
            else
            {
                Console.WriteLine("Invalid position. Position should be within the string length.");
            }
        }

        static void SwapFirstLast()
        {
            Console.WriteLine("Enter a string:");
            string data = Console.ReadLine();

            if (string.IsNullOrEmpty(data) || data.Length == 1)
            {
                Console.WriteLine($"No change: {data}");
            }
            else
            {

                char firstChar = data[0];
                char lastChar = data[data.Length - 1];
                string swappedString = lastChar + data.Substring(1, data.Length - 2) + firstChar;

                Console.WriteLine($"Swapped string: {swappedString}");
            }
        
        }

        static void Main(string[] args)
        {
            Console.WriteLine("---Largest Numbers--");
            LargestNum();

            Console.WriteLine("---Remove Character at Position---");
            RemoveCharAtPosition();
            Console.WriteLine("---SwapString---");
            SwapFirstLast();

            Console.Read();
        }
    }
}
    

        
