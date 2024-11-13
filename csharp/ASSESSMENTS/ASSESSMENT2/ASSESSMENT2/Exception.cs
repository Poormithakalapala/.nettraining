using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Exception
{
    
    public static void CheckNumber(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Number cannot be negative");
        }
        else
        {
            Console.WriteLine("The number is: " + number);
        }
    }

    static void Main()
    {
        try
        {
            
            Console.Write("Enter a number: ");
            int userInput = int.Parse(Console.ReadLine());

            
            CheckNumber(userInput);
        }
        catch (ArgumentException ex)
        {
            
            Console.WriteLine("Error: " + ex.Message);
        }
        
        Console.ReadLine();
    }
}
