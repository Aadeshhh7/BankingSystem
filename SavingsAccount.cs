using System;

public class SavingsAccount : Account
{
    private double interestRate = 5;

    public SavingsAccount(string name, int accNo, double balance)
        : base(name, accNo, balance)
    {
    }

    public override void AddInterest()
    {
        double interest = balance * interestRate / 100;
        balance += interest;

        Console.WriteLine("Savings Interest Added: " + interest);
    }
}