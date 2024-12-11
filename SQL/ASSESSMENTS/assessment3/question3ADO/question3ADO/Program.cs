using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question3ADO
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    namespace question3ADO
    {
        class Program
        {
            static void Main(string[] args)
            {

                string connectionString = "Server=ICS-LT-8ZFLQ73\\SQLEXPRESS;Database=master;Trusted_Connection=True";

                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        
                        conn.Open();

                        // Create a command to execute the stored procedure
                        using (SqlCommand cmd = new SqlCommand("Insert_ProdDetai", conn))  // Make sure the name matches the stored procedure
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters for the stored procedure
                            cmd.Parameters.AddWithValue("@ProductName", "Shoes");
                            cmd.Parameters.AddWithValue("@Price", 10000);

                            // Define the output parameter for GeneratedProductId
                            SqlParameter productIdParam = new SqlParameter("@GeneratedProductId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(productIdParam);

                            // Execute the stored procedure
                            cmd.ExecuteNonQuery();

                            // Retrieve the output value for GeneratedProductId
                            int generatedProductId = (int)productIdParam.Value;

                            // Output the generated ProductId
                            Console.WriteLine($"Generated ProductId: {generatedProductId}");

                            // Retrieve the DiscountedPrice (calculated in the database) by ProductId
                            using (SqlCommand getDiscountedPriceCmd = new SqlCommand("SELECT DiscountedPrice FROM Products_Detail WHERE ProductId = @GeneratedProductId", conn))
                            {
                                getDiscountedPriceCmd.Parameters.AddWithValue("@GeneratedProductId", generatedProductId);
                                decimal discountedPrice = (decimal)getDiscountedPriceCmd.ExecuteScalar();

                                // Output the DiscountedPrice
                                Console.WriteLine($"Discounted Price: {discountedPrice}");
                            }

                            // Wait for user input before closing the console window
                            Console.WriteLine("Press Enter to exit...");
                            Console.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that occur
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
    }

}