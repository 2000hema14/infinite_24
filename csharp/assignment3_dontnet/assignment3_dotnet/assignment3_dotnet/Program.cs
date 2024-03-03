using System;
using System.Collections.Generic;
using System.Linq;

public class Accounts
{
    public string AccountNo { get; private set; }
    public string CustomerName { get; private set; }
    public string AccountType { get; private set; }
    private List<Tuple<char, double>> transactions;

    public Accounts(string accountNo, string customerName, string accountType)
    {
        AccountNo = accountNo;
        CustomerName = customerName;
        AccountType = accountType;
        transactions = new List<Tuple<char, double>>();
    }

    public bool Deposit(double amount)
    {
        transactions.Add(Tuple.Create('D', amount));
        return true; // Deposit is always successful in this implementation
    }

    public bool Withdraw(double amount)
    {
        if (Balance >= amount)
        {
            transactions.Add(Tuple.Create('W', amount));
            return true; // Withdrawal successful
        }
        else
        {
            Console.WriteLine("Insufficient balance!");
            return false; // Withdrawal failed due to insufficient balance
        }
    }

    public double Balance
    {
        get
        {
            double totalDeposits = transactions.Where(t => t.Item1 == 'D').Sum(t => t.Item2);
            double totalWithdrawals = transactions.Where(t => t.Item1 == 'W').Sum(t => t.Item2);
            return totalDeposits - totalWithdrawals;
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Account Number: " + AccountNo);
        Console.WriteLine("Customer Name: " + CustomerName);
        Console.WriteLine("Account Type: " + AccountType);
        Console.WriteLine("Balance: " + Balance);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Accounts account = new Accounts("1034321", "Hemalatha", "Current");
        account.DisplayInfo();
        Console.WriteLine();

        bool depositSuccess = account.Deposit(1000);
        if (depositSuccess)
        {
            Console.WriteLine("Deposit successful!");
        }
        else
        {
            Console.WriteLine("Deposit failed!");
        }
        account.DisplayInfo();
        Console.WriteLine();

        bool withdrawalSuccess = account.Withdraw(500);
        if (withdrawalSuccess)
        {
            Console.WriteLine("Withdrawal successful!");
        }
        else
        {
            Console.WriteLine("Withdrawal failed!");
        }
        account.DisplayInfo();
        Console.WriteLine();

        bool anotherWithdrawalSuccess = account.Withdraw(1000);
        if (anotherWithdrawalSuccess)
        {
            Console.WriteLine("Withdrawal successful!");
        }
        else
        {
            Console.WriteLine("Withdrawal failed!");
        }
        account.DisplayInfo();
        Console.ReadLine();
        
       
    }
}