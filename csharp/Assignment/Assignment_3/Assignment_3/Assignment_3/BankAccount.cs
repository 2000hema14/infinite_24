using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{

}
class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException() : base("Insufficient balance.")
    {
    }

    public InsufficientBalanceException(string message) : base(message)
    {
    }

    public InsufficientBalanceException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

class BankAccount
{
    private string accountNumber;
    private string accountHolderName;
    private double balance;

    public BankAccount(string accountNumber, string accountHolderName, double initialBalance)
    {
        this.accountNumber = accountNumber;
        this.accountHolderName = accountHolderName;
        this.balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount. Amount must be greater than zero.");
        }
        else
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}. New balance: {balance}");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount. Amount must be greater than zero.");
        }
        else if (amount > balance)
        {
            throw new InsufficientBalanceException();
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}. New balance: {balance}");
        }
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account Balance: {balance}");
    }
}

class BankAcc
{
    static void Main()
    {
        BankAccount account = new BankAccount("10765", "hema", 1000);

        account.Deposit(2000);
        try
        {
            account.Withdraw(3500); // 
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }

        account.CheckBalance();
        Console.ReadLine();
    }
}

