using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
     class Account
        {
            private string accountNo;
            private string customerName;
            private string accountType;
            private double acBalance;


            public Account(string accountNo, string customerName, string accountType, double checkBalance)
            {
                this.accountNo = accountNo;
                this.customerName = customerName;
                this.accountType = accountType;
                this.acBalance = checkBalance;
            }

            // Method for deposit
            public void Credit(int amount)
            {
                acBalance += amount;
                Console.WriteLine($"Deposited ammount: {amount} / current balance is: {acBalance}");
            }

            // Method for withdrawal
            public void Debit(int amount)
            {
                if (amount <= acBalance)
                {
                    acBalance -= amount;
                    Console.WriteLine($"Withdrawn amount: {amount} / current balance is: {acBalance}");
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }


            public void UpdateBalance(char transactionType, int amount)
            {
                if (transactionType == 'D' || transactionType == 'd') // Deposit
                {
                    Credit(amount);
                }
                else if (transactionType == 'W' || transactionType == 'w') // Withdrawal
                {
                    Debit(amount);
                }
                else
                {
                    Console.WriteLine("Invalid transaction type.");
                }
            }

            // Method to display account details
            public void ShowData()
            {
                Console.WriteLine("\nAccount Details:");
                Console.WriteLine($"Account No: {accountNo}");
                Console.WriteLine($"Customer Name: {customerName}");
                Console.WriteLine($"Account Type: {accountType}");
                Console.WriteLine($"Balance: {acBalance}");
            }
        }
        class Inheritance
        {
            static void Main()
            {
                Console.Write("Enter Account Number: ");
                string accountNo = Console.ReadLine();

                Console.Write("Enter Customer Name: ");
                string customerName = Console.ReadLine();

                Console.Write("Enter Account Type: ");
                string accountType = Console.ReadLine();

                Console.Write("Enter check Balance: ");
                double checkBalance = Convert.ToDouble(Console.ReadLine());
                Account account = new Account(accountNo, customerName, accountType, checkBalance);

                account.ShowData();


                Console.Write("\nEnter transaction type--(D for Deposit / W for Withdrawal): ");
                char transactionType = Char.ToUpper(Console.ReadKey().KeyChar);

                Console.Write("\nEnter amount: ");
                int amount = Convert.ToInt32(Console.ReadLine());


                account.UpdateBalance(transactionType, amount);


                account.ShowData();
                Console.Read();
            }

        }
    }

