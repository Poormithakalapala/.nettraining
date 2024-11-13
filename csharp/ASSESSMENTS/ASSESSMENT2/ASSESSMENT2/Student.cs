using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASSESSMENT2
{
    
    public abstract class Student
    {
        
        public string StudentName;
        public int StudentId;
        public double Grade;

        
        public abstract bool IsPassed(double grade);
    }

   
    public class Undergraduate : Student
    {
       
        public override bool IsPassed(double grade)
        {
            
            return grade > 70.0;
        }
    }

    
    public class Graduate : Student
    {
       
        public override bool IsPassed(double grade)
        {
            
            return grade > 80.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Undergraduate undergrad = new Undergraduate();
            Graduate grad = new Graduate();

            
            Console.WriteLine("Enter Undergraduate Student Details:");
            Console.Write("Name: ");
            undergrad.StudentName = Console.ReadLine();
            Console.Write("Student ID: ");
            undergrad.StudentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Grade: ");
            undergrad.Grade = Convert.ToDouble(Console.ReadLine());

           
            Console.WriteLine("\nEnter Graduate Student Details:");
            Console.Write("Name: ");
            grad.StudentName = Console.ReadLine();
            Console.Write("Student ID: ");
            grad.StudentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Grade: ");
            grad.Grade = Convert.ToDouble(Console.ReadLine());

           
            Console.WriteLine($"\n{undergrad.StudentName} (Undergraduate) - Passed: {undergrad.IsPassed(undergrad.Grade)}");
            Console.WriteLine($"{grad.StudentName} (Graduate) - Passed: {grad.IsPassed(grad.Grade)}");

            
            Console.WriteLine("\nTest with new grades (failed):");
            Console.Write("\nEnter new grade for Undergraduate student: ");
            undergrad.Grade = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter new grade for Graduate student: ");
            grad.Grade = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"\n{undergrad.StudentName} (Undergraduate) - Passed: {undergrad.IsPassed(undergrad.Grade)}");
            Console.WriteLine($"{grad.StudentName} (Graduate) - Passed: {grad.IsPassed(grad.Grade)}");

            Console.ReadLine();
        }
    }
}

