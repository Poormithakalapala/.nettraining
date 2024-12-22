using System;
using System.Data.SqlClient;

namespace MiniProject
{
    public class UserLogin
    {
        public static void Login()
        {
            Console.Clear();
            Console.WriteLine("User Login");
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            var parameters = new[] {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            var table = Database.ExecuteQuery(query, parameters);

            if (table.Rows.Count > 0)
            {
                int userId = (int)table.Rows[0]["UserId"];
                Console.WriteLine("Login successful. Press Enter to continue.");
                Console.ReadLine();
                UserOperations.UserMenu(userId);
            }
            else
            {
                Console.WriteLine("Invalid credentials. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }
}
