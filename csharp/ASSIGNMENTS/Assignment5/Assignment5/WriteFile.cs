using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5
{
    class WriteFile
    {
        public static void Main()
        {
            Console.Write("Enter the number of lines you want to write to the file: ");
            int numberOfLines = int.Parse(Console.ReadLine());


            string[] lines = new string[numberOfLines];


            for (int i = 0; i < numberOfLines; i++)
            {
                Console.Write($"Enter line {i + 1}: ");
                lines[i] = Console.ReadLine();
            }


            string filePath = "user_output.txt";

            try
            {
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Lines written to the file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            Console.Read();
        }
    }
}