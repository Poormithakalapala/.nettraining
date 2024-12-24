using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class AdminLogin
    {
        public static void Login()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("ADMIN LOGIN");
            Console.Write("Enter Admin Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            string query = "SELECT * FROM Admins WHERE Username = @Username AND Password = @Password";
            var parameters = new[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            var table = Database.ExecuteQuery(query, parameters);

            if (table.Rows.Count > 0)
            {
                Console.WriteLine("Login successful. Press Enter to continue.");
                Console.ReadLine();
                AdminOperations.AdminMenu();
            }
            else
            {
                Console.WriteLine("Incorrect credentials. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }
}