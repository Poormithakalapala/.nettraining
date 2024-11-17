using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class squarequery
    {
        static void Main()
        {
            Console.WriteLine("Enter a list of integers: ");
            string input =Convert.ToString( Console.ReadLine());
            List<int> numbers = new List<int>();
            int CurrentNo = 0;

           foreach( char c in input)
            {
                if (char.IsDigit(c))
                {
                    CurrentNo = CurrentNo * 10 + (c - '0');
                }
                else if(c==' ')
                {
                    numbers.Add(CurrentNo);
                    CurrentNo = 0;
                }
            }
            numbers.Add(CurrentNo);

            var result = from n in numbers
                         let square = n * n
                         where square > 20
                         select $"{n}-{square}";

            Console.WriteLine("Numbers and their squares:");
            Console.WriteLine(string.Join(",", result));
            Console.ReadLine();
        }
        
    }
}
