using System;

public class Account
{
    protected string holderName;
    protected int accountNumber;
    protected double balance;
    protected double loan;

    public Account(string name, int accNo, double balance)
    {
        holderName = name;
        accountNumber = accNo;
        this.balance = balance;
        loan = 0;
    }

    public virtual void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine("Deposit Successful!");
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine("Withdrawal Successful!");
        }
        else
        {
            Console.WriteLine("Insufficient Balance!");
        }
    }

    public void TakeLoan(double amount)
    {
        loan += amount;
        balance += amount;

        Console.WriteLine("Loan Approved!");
    }

    public void SendMoney(Account receiver, double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            receiver.balance += amount;

            Console.WriteLine("Money Sent Successfully!");
        }
        else
        {
            Console.WriteLine("Insufficient Balance!");
        }
    }

    public virtual void AddInterest()
    {
        Console.WriteLine("No Interest Available.");
    }

    public virtual void ViewDetails()
    {
        Console.WriteLine("\n--- Account Details ---");
        Console.WriteLine("Name: " + holderName);
        Console.WriteLine("Account Number: " + accountNumber);
        Console.WriteLine("Balance: " + balance);
        Console.WriteLine("Loan: " + loan);
    }
}