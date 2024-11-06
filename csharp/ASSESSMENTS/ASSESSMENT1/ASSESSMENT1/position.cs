using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSESSMENT1
{
    class position
    {
        public static string RemoveCharAt(string str, int index)
        {
            if (index < 0 || index >= str.Length)
            {
                Console.WriteLine("Index out of range");
                return str;
            }
            return str.Remove(index, 1);
        }
        static string ExchangeFirstAndLast(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length == 1)
            {
                return str;
            }
            char firstChar = str[0];
            char lastChar = str[str.Length - 1];
            string newStr = lastChar + str.Substring(1, str.Length - 2) + firstChar;
            return newStr;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(RemoveCharAt("python", 1));
            Console.WriteLine(RemoveCharAt("python", 0));
            Console.WriteLine(RemoveCharAt("python", 3));
            Console.WriteLine(RemoveCharAt("python", 4));
            Console.WriteLine("========Exchange First and last character=======");
            string input1 = "abcd";
            string input2 = "xy";
            Console.WriteLine(ExchangeFirstAndLast(input1));
            Console.WriteLine(ExchangeFirstAndLast(input2));
        }
    }
}
