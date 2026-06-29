using System;

class Program
{
    static Account account;
    static Account receiver;

    static string username;
    static string password;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== BANK SYSTEM =====");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");

            Console.Write("Enter Choice: ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Register();
                        break;

                    case 2:
                        Login();
                        break;

                    case 3:
                        Console.WriteLine("Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

 
    static void Register()
    {
        try
        {
            Console.Write("Create Username: ");
            username = Console.ReadLine();

            Console.Write("Create Password: ");
            password = Console.ReadLine();

            Console.WriteLine("\nRegistration Successful!");

            CreateAccount();

            Console.WriteLine("\nNow you can login.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in Register: " + ex.Message);
        }
    }

  
    static void Login()
    {
        try
        {
            if (username == null)
            {
                Console.WriteLine("Please register first!");
                return;
            }

            Console.Write("Enter Username: ");
            string user = Console.ReadLine();

            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();

            if (user == username && pass == password)
            {
                Console.WriteLine("\nLogin Successful!");

                if (account == null)
                {
                    Console.WriteLine("No account found. Please create one.");
                    CreateAccount();
                }

                MainMenu();
            }
            else
            {
                Console.WriteLine("Invalid credentials!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Login Error: " + ex.Message);
        }
    }

   
    static void CreateAccount()
    {
        try
        {
            Console.WriteLine("\n===== CREATE ACCOUNT =====");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Account Number: ");
            int accNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Starting Balance: ");
            double balance = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nChoose Account Type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.WriteLine("3. Fixed Deposit Account");

            Console.Write("Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    account = new SavingsAccount(name, accNo, balance);
                    break;

                case 2:
                    account = new CurrentAccount(name, accNo, balance);
                    break;

                case 3:
                    Console.Write("Enter FD Months: ");
                    int months = Convert.ToInt32(Console.ReadLine());

                    account = new FixedDepositAccount(name, accNo, balance, months);
                    break;

                default:
                    Console.WriteLine("Invalid account type!");
                    return;
            }

            Console.WriteLine("Account created successfully!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in CreateAccount: " + ex.Message);
        }
    }

  
    static void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("\n===== MAIN MENU =====");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Loan");
            Console.WriteLine("4. Send Money");
            Console.WriteLine("5. Interest");
            Console.WriteLine("6. View Details");
            Console.WriteLine("7. Logout");

            Console.Write("Enter Choice: ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DepositMoney();
                        break;

                    case 2:
                        WithdrawMoney();
                        break;

                    case 3:
                        TakeLoan();
                        break;

                    case 4:
                        SendMoney();
                        break;

                    case 5:
                        account.AddInterest();
                        break;

                    case 6:
                        account.ViewDetails();
                        break;

                    case 7:
                        Console.WriteLine("Logged out!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Menu Error: " + ex.Message);
            }
        }
    }


    static void DepositMoney()
    {
        try
        {
            Console.Write("Enter Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            account.Deposit(amount);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Deposit Error: " + ex.Message);
        }
    }

    static void WithdrawMoney()
    {
        try
        {
            Console.Write("Enter Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            account.Withdraw(amount);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Withdraw Error: " + ex.Message);
        }
    }

    static void TakeLoan()
    {
        try
        {
            Console.Write("Enter Loan Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            account.TakeLoan(amount);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Loan Error: " + ex.Message);
        }
    }

    static void SendMoney()
    {
        try
        {
            Console.WriteLine("\nReceiver Details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Account No: ");
            int accNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Balance: ");
            double balance = Convert.ToDouble(Console.ReadLine());

            receiver = new CurrentAccount(name, accNo, balance);

            Console.Write("Enter Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            account.SendMoney(receiver, amount);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Send Money Error: " + ex.Message);
        }
    }
}