using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Employee
    {
        public int EmpId { get; set; }
        public string eName { get; set; }
        public string eCity { get; set; }
        public double eSal { get; set; }

    }
    class Emp

    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();

            Console.WriteLine("Enter the no.of Employess: ");
            int NoofEmployees = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < NoofEmployees; i++)
            {
                Console.WriteLine($"\nEnter details for Employee{i + 1}:");

                Console.WriteLine("EmpId: ");
                int EmpId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("EName: ");
                string eName = Console.ReadLine();

                Console.WriteLine("Ecity: ");
                string eCity = Console.ReadLine();

                Console.WriteLine("eSal: ");
                double eSal = Convert.ToDouble(Console.ReadLine());

                employees.Add(new Employee
                {
                    EmpId = EmpId,
                    eName = eName,
                    eCity = eCity,
                    eSal = eSal
                });
            }
            //Display all employees data
            Console.WriteLine("\nAll Employee Data: ");
            IEnumerable<Employee> allEmployees = from emp in employees
                                                 select emp;
            DisplayEmployeeData(allEmployees);

            //Display all employees data whose salary is greater than 45000
            Console.WriteLine("\nEmployees with salary greater than 45000");
            IEnumerable<Employee> highSalEmployees = from emp in employees
                                                     where emp.eSal > 45000
                                                     select emp;
            DisplayEmployeeData(highSalEmployees);

            //Display all employees data who belong to Bangalore region
            Console.WriteLine("\nEmployees from Bangalore");
            IEnumerable<Employee> BangaloreEmp = from emp in employees
                                                 where emp.eCity == "Bangalore"
                                                 select emp;
            DisplayEmployeeData(BangaloreEmp);

            //Display all employees data sorted by their name in ascending order
            Console.WriteLine("\nEmployees sorted by name in ascending order:");
            IEnumerable<Employee> sortedEmployees = from emp in employees
                                                    orderby emp.eName
                                                    select emp;
            DisplayEmployeeData(sortedEmployees);
            Console.ReadLine();
        }
        static void DisplayEmployeeData(IEnumerable<Employee> employees)
        {
            foreach(var employee in employees)
            {
                Console.WriteLine($"EmpId: {employee.EmpId}, Name:{employee.eName}, City:{employee.eCity}, salary:{employee.eSal}");
               
            }
            
        }
       
    }
}
