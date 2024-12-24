using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class Registrations
    {
        public static void Registration()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("*             REGISTRATION                *");
            Console.Write("Enter Username: ");
            var username = Console.ReadLine();

            Console.Write("Enter Password: ");
            var password = Console.ReadLine();

            Console.Write("Are you registering as an Admin or User? (A/U): ");
            var role = Console.ReadLine().ToUpper();

            string query = role == "A" ?
                "INSERT INTO Admins (Username, Password) VALUES (@Username, @Password)" :
                "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";

            var parameters = new[]
            {
            new SqlParameter("@Username", username),
            new SqlParameter("@Password", password)
        };

            try
            {
                Database.ExecuteNonQuery(query, parameters);
                Console.WriteLine("Registration successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}