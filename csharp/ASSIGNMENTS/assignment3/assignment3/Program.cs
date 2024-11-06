using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    class Program
    {
        static void Lengthh()
        {
            Console.WriteLine("Enter a word");
            string word = Console.ReadLine();
            Console.WriteLine(word.Length);
               
        }
        static void Reversestr()
        {
            Console.WriteLine("Enter a string");
            string data =Console.ReadLine();
            string reverseword = "";

            for (int i= data.Length-1;i>=0;i--)
            {
                reverseword += data[i];
            }
            Console.WriteLine("Reversestring: " + reverseword);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("---length--");
            Lengthh();
           
            Console.WriteLine("---reverse--");
            Reversestr();

            Console.Read();
        }
    }
}
