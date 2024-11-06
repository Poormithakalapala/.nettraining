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
        static void SameorNot()
        {
            Console.WriteLine("Enter 1st word: ");
            string word1 = Console.ReadLine();
            Console.WriteLine("Enter 2nd word: ");
            string word2 = Console.ReadLine();

            if (word1==word2)
            {
                Console.WriteLine("they are same");
            }
            else
            {
                Console.WriteLine("They are not same");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("---length--");
            Lengthh();
           
            Console.WriteLine("---reverse--");
            Reversestr();

            Console.WriteLine("---Sameornot--");
            SameorNot();

            Console.Read();
        }
    }
}
