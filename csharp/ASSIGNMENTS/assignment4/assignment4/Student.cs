using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Student

    {
        public static void Main()
        {

            Console.Write("Student ID: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name: ");
            string b = Console.ReadLine();

            IStudent dayscholar = new Dayscholar() { StudentId = a, Name = b };


            Console.Write("Student ID: ");
            int c = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name: ");
            string d = Console.ReadLine();

            IStudent resident = new Resident() { StudentId = c, Name = d };

            dayscholar.ShowDetails();
            resident.ShowDetails();
            Console.ReadLine();
        }
    }
    public interface IStudent
    {
        int StudentId { get; set; }
        string Name { get; set; }
        void ShowDetails();
    }

    public class Dayscholar : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine($"Dayscholar - Student ID: {StudentId}, Name: {Name}");
        }
    }

    public class Resident : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine($"Resident - Student ID: {StudentId}, Name: {Name}");
        }
    }
}
