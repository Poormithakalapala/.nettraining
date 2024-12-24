using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("*    WELCOME TO RAILWAY RESERVATION  *");
                Console.WriteLine();
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Admin Login");
                Console.WriteLine("3. User Login");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("---------------------------------------------");
                        Registrations.Registration();
                        break;
                    case "2":
                        Console.WriteLine("---------------------------------------------");
                        AdminLogin.Login();
                        break;
                    case "3":
                        Console.WriteLine("---------------------------------------------");
                        UserLogin.Login();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}