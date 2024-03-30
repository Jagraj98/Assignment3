using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    public enum AccountType
        {
            CheckingAccount,
            SavingsAccount
        }
        public class BankAccount
        {
            public string AccountNumber { get; private set; }
            public decimal Balance { get; private set; }
            public AccountType Type { get; private set; }

            public BankAccount(string accountNumber, decimal initialBalance)
            {
                AccountNumber = accountNumber;
                Balance = initialBalance;
                Type = AccountType.CheckingAccount; 
            }
            public BankAccount(string accountNumber, decimal initialBalance, AccountType type)
            {
                AccountNumber = accountNumber;
                Balance = initialBalance;
                Type = type;
            }

            public void Deposit(decimal amount)
            {
                Balance += amount;
                Console.WriteLine($"{amount:C} deposited into account {AccountNumber}. New balance: {Balance:C}");
            }

            public void Withdraw(decimal amount)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"{amount:C} withdrawn from account {AccountNumber}. New balance: {Balance:C}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }

            public void Deposit(decimal amount, string description)
            {
                Deposit(amount);
                Console.WriteLine($"Description: {description}");
            }

            public void Withdraw(decimal amount, string description)
            {
                Withdraw(amount);
                Console.WriteLine($"Description: {description}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                BankAccount checkingAccount = new BankAccount("121212", 1000m);
                checkingAccount.Deposit(500m);
                checkingAccount.Withdraw(200m);

                BankAccount savingsAccount = new BankAccount("343434", 2000m, AccountType.SavingsAccount);
                savingsAccount.Deposit(1000m);
                savingsAccount.Withdraw(250m);

                checkingAccount.Deposit(300m, "Salary");
                savingsAccount.Withdraw(150m, "Emergency expense");
            }
        }

 }

