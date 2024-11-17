using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class letterquery
    {
        static void Main()
        {
            Console.WriteLine("enter words:");

            string Input = Console.ReadLine();
            List<string> words = new List<string>();
            string currentword = "";

           foreach(char c in Input)
            {
                if (char.IsLetter(c))
                {
                    currentword += c;
                }
                else if(c==' ')
                {
                    if (!string.IsNullOrEmpty(currentword))
                    {
                        words.Add(currentword);
                        currentword = "";
                    }
                }
            }
            if (!string.IsNullOrEmpty(currentword))
            {
                words.Add(currentword);
            }

            IEnumerable<string> Fwords = from word in words
                                        where word.StartsWith("a") && word.EndsWith("m")
                                        select word;

            Console.WriteLine("Words starting with 'a' and ending with 'm'");
            Console.WriteLine(string.Join(",", Fwords));

            Console.ReadLine();
                     
        }
    }
}
