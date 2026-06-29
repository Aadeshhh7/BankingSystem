using System;

public class FixedDepositAccount : Account
{
    private int months;
    private double interestRate = 8;

    public FixedDepositAccount(string name, int accNo, double balance, int months)
        : base(name, accNo, balance)
    {
        this.months = months;
    }

    public override void AddInterest()
    {
        double years = months / 12.0;
        double interest = balance * interestRate * years / 100;

        balance += interest;

        Console.WriteLine("FD Interest Added: " + interest);
    }
}