using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5
{
    class ReadFile
    {
        public static void Main()
        {
            string filePath = "user_output.txt";

            try
            {
                int lineCount = File.ReadAllLines(filePath).Length;
                Console.WriteLine($"Number of lines in the file: {lineCount}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Please make sure the file exists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            Console.Read();
        }
    }
}