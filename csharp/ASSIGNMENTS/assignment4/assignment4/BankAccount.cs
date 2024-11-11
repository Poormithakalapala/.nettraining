using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    public class BankAccount
    {
        double balance;

        public BankAccount(double initialBalance)
        {
            balance = initialBalance;
        }
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Deposited: " + amount);
            }
            else
            {
                Console.WriteLine("Invalid deposit amount");
            }
        }
        public void Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Withdrew: " + amount);
            }
            else
            {
                throw new InsufficientBalanceException("Insufficient balance to withdraw " + amount);
            }
        }

        public double GetBalance()
        {
            return balance;
        }
    }

    public class Banking
    {
        public static void Main(string[] args)
        {
            try
            {
                BankAccount account = new BankAccount(2000);
                account.Deposit(2000);
                account.Withdraw(4000);
                Console.WriteLine("Remaining Balance: " + account.GetBalance());
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.Read();
        }
    }
}
