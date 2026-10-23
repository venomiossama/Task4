using System;
using System.Collections.Generic;

namespace Task4
{
    public interface IAccount
    {
        string Name { get; set; }
        double Balance { get; set; }

        bool Deposit(double amount);
        bool Withdraw(double amount);
    }

    public class Account : IAccount
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static class AccountUtil
    {
        public static void Deposit(List<IAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.Name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
            }
        }

        public static void Withdraw(List<IAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc.Name}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
            }
        }
    }

    public class SavingsAccount : Account
    {
        public double interestrate { get; set; }

        public SavingsAccount(string name = "Unnamed Account", double balance = 0.0, double interestrate = 0.0) : base(name, balance)
        {
            this.interestrate = interestrate;
        }

        public override bool Deposit(double amount)
        {
            double interest = amount * (interestrate / 100);
            double totalamount = amount + interest;
            return base.Deposit(totalamount);
        }
    }

    public class CheckingAccount : Account
    {
        public double fee { get; set; }

        public CheckingAccount(string name = "Unnamed Account", double balance = 0.0, double fee = 0.0) : base(name, balance)
        {
            this.fee = fee;
        }

        public override bool Withdraw(double amount)
        {
            double Feetotal = fee + amount;
            return base.Withdraw(Feetotal);
        }
    }

    public class TrustAccount : SavingsAccount
    {
        public int withdrawcount { get; set; } = 0;

        public TrustAccount(string name = "Unnamed Account", double balance = 0.0, double interestrate = 0.0) : base(name, balance, interestrate)
        {
        }

        public override bool Deposit(double amount)
        {
            if (amount >= 5000)
            {
                amount += 50;
            }
            return base.Deposit(amount);
        }

        public override bool Withdraw(double amount)
        {
            if (withdrawcount < 3 && amount <= (Balance * 0.20))
            {
                bool isSuccessful = base.Withdraw(amount);
                if (isSuccessful == true)
                {
                    withdrawcount++;
                    return true;
                }
            }

            return false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Accounts
            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            List<IAccount> savAccounts = new List<IAccount>();
            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.Deposit(savAccounts, 1000);
            AccountUtil.Withdraw(savAccounts, 2000);

            // Checking
            List<IAccount> checAccounts = new List<IAccount>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.Deposit(checAccounts, 1000);
            AccountUtil.Withdraw(checAccounts, 2000);
            AccountUtil.Withdraw(checAccounts, 2000);

            // Trust
            List<IAccount> trustAccounts = new List<IAccount>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

            AccountUtil.Deposit(trustAccounts, 1000);
            AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 2000);
            AccountUtil.Withdraw(trustAccounts, 3000);
            AccountUtil.Withdraw(trustAccounts, 500);

            Console.WriteLine();
            //el task absat mn elly fat
        }
    }
}