using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSESSMENT2
{
    public class Product
    {
        public int ProductId;      
        public string ProductName;  
        public decimal Price;     

        
        public Product(int productId, string productName, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

        public override string ToString()
        {
            return $"Product ID: {ProductId}, Name: {ProductName}, Price: {Price:C}";
        }
    }

    
    public class ProductPriceComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            
            return x.Price.CompareTo(y.Price);
        }
    }

    class Programs
    {
        static void Main()
        {
            
            List<Product> products = new List<Product>();

            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter details for product {i + 1}:");

                
                Console.Write("Product ID: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Product Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                
                Product product = new Product(productId, productName, price);
                products.Add(product);

                Console.WriteLine(); 
            }

            
            products.Sort(new ProductPriceComparer());

            
            Console.WriteLine("\nSorted Products by Price:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
               
            }
            Console.ReadLine();
        }
    }
}
