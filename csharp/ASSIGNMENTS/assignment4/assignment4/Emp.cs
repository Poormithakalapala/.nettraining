using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Emp

    {
        public static void Main()
        {


            Console.Write("Employee ID: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Employee Name: ");
            string b = Console.ReadLine();

            Console.Write("Salary: ");
            float c = Convert.ToSingle(Console.ReadLine());

            Console.Write("Wages: ");
            float d = Convert.ToSingle(Console.ReadLine());

            ParttimeEmployee partTimeEmployee = new ParttimeEmployee(a, b, c, d);
            partTimeEmployee.DisplayParttimeEmployeeDetails();
            Console.ReadLine();
        }
    }
    public class Employee
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public float Salary { get; set; }

        public Employee(int empid, string empname, float salary)
        {
            Empid = empid;
            Empname = empname;
            Salary = salary;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Employee ID: {Empid}, Name: {Empname}, Salary: {Salary}");
        }
    }

    public class ParttimeEmployee : Employee
    {
        public float Wages { get; set; }

        public ParttimeEmployee(int empid, string empname, float salary, float wages)
            : base(empid, empname, salary)
        {
            Wages = wages;
        }

        public void DisplayParttimeEmployeeDetails()
        {
            DisplayEmployeeDetails();
            Console.WriteLine($"Wages: {Wages}");
        }
    }
}

