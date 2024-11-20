using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSESSMENT3
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "text_file.txt"; 

            Console.WriteLine("Enter the text you want to append to the file:");
            string Input = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true)) 
                {
                    writer.WriteLine(Input);
                }

                Console.WriteLine($"\nSuccessfully appended to the file '{filePath}'.");
                Console.WriteLine("file:");

                string fileContents = File.ReadAllText(filePath);
                Console.WriteLine(fileContents);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(ex.Message);
               
            }
            Console.Read();
        }
    }
}