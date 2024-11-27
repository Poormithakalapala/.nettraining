using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public string City { get; set; }

    public Employee(int id, string firstName, string lastName, string title, string city)
    {
        EmployeeID = id;
        FirstName = firstName;
        LastName = lastName;
        Title = title;
        City = city;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Employee> empList = new List<Employee>
        {
            new Employee(1001, "Malcolm", "Daruwalla", "Manager", "Mumbai"),
            new Employee(1002, "Asdin", "Dhalla", "AsstManager", "Mumbai"),
            new Employee(1003, "Madhavi", "Oza", "Consultant", "Pune"),
            new Employee(1004, "Saba", "Shaikh", "SE", "Pune"),
            new Employee(1005, "Nazia", "Shaikh", "SE", "Mumbai"),
            new Employee(1006, "Amit", "Pathak", "Consultant", "Chennai"),
            new Employee(1007, "Vijay", "Natrajan", "Consultant", "Mumbai"),
            new Employee(1008, "Rahul", "Dubey", "Associate", "Chennai"),
            new Employee(1009, "Suresh", "Mistry", "Associate", "Chennai"),
            new Employee(1010, "Sumit", "Shah", "Manager", "Pune")
        };

        // a. Display details of all the employees
        Console.WriteLine("a. Display details of all employees:");
        var allEmployees = from emp in empList
                           select new { emp.EmployeeID, emp.FirstName, emp.LastName, emp.Title, emp.City };
        foreach (var emp in allEmployees)
        {
            Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
        }

        Console.WriteLine("-------------------------------------");
        Console.ReadLine();  

        // b. Display details of all the employees whose location is not Mumbai
        Console.WriteLine("\nb. Display details of all employees whose location is not Mumbai:");
        var employeesNotInMumbai = from emp in empList
                                   where emp.City != "Mumbai"
                                   select new { emp.EmployeeID, emp.FirstName, emp.LastName, emp.Title, emp.City };
        foreach (var emp in employeesNotInMumbai)
        {
            Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
        }

        Console.WriteLine("-----------------------------------------");
        Console.ReadLine();  
        // c. Display details of all the employees whose title is AsstManager
        Console.WriteLine("\nc. Display details of all employees whose title is AsstManager:");
        var asstManagers = from emp in empList
                           where emp.Title == "AsstManager"
                           select new { emp.EmployeeID, emp.FirstName, emp.LastName, emp.Title, emp.City };
        foreach (var emp in asstManagers)
        {
            Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
        }

        Console.WriteLine("-------------------------------");
        Console.ReadLine();  

        // d. Display details of all the employees whose last name starts with 'S'
        Console.WriteLine("\nd. Display details of all employees whose last name starts with 'S':");
        var employeesWithLastNameS = from emp in empList
                                     where emp.LastName.StartsWith("S")
                                     select new { emp.EmployeeID, emp.FirstName, emp.LastName, emp.Title, emp.City };
        foreach (var emp in employeesWithLastNameS)
        {
            Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
        }

        
        Console.WriteLine("------------------------");
        Console.ReadLine();
    }
}
