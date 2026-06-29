using System;

public class CurrentAccount : Account
{
    public CurrentAccount(string name, int accNo, double balance)
        : base(name, accNo, balance)
    {
    }

    public override void AddInterest()
    {
        Console.WriteLine("Current Account has no interest.");
    }
}