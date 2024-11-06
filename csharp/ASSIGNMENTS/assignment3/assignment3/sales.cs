using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    internal class Sales
    {
        class Saledetails
        {
            private int salesNo;
            private int productNo;
            private double price;
            private DateTime dateOfSale;
            private int qty;
            private double totalAmount;


            public Saledetails(int salesNo, int productNo, double price, int qty, DateTime dateOfSale)
            {
                this.salesNo = salesNo;
                this.productNo = productNo;
                this.price = price;
                this.qty = qty;
                this.dateOfSale = dateOfSale;
                Sales();
            }


            public void Sales()
            {
                totalAmount = qty * price;
            }


            public void ShowData()
            {
                Console.WriteLine("\nSale Details:");
                Console.WriteLine($"Sales No: {salesNo}");
                Console.WriteLine($"Product No: {productNo}");
                Console.WriteLine($"Price: {price:C}");
                Console.WriteLine($"Quantity: {qty}");
                Console.WriteLine($"Date of Sale: {dateOfSale:dd/MM/yyyy}");
                Console.WriteLine($"Total Amount: {totalAmount:C}");
                Console.Read();
            }
        }

        class Product
        {
            static void Main()
            {

                Console.Write("Enter Sales No: ");
                int salesNo = int.Parse(Console.ReadLine());

                Console.Write("Enter Product No: ");
                int productNo = int.Parse(Console.ReadLine());

                Console.Write("Enter Price: ");
                double price = double.Parse(Console.ReadLine());

                Console.Write("Enter Quantity: ");
                int qty = int.Parse(Console.ReadLine());

                Console.Write("Enter Date of Sale (yyyy-mm-dd): ");
                DateTime dateOfSale = DateTime.Parse(Console.ReadLine());


                Saledetails sale = new Saledetails(salesNo, productNo, price, qty, dateOfSale);
                sale.ShowData();
            }
        }
    }
}
