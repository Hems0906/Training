using System;

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}

public class BankAccount
{
    private decimal balance;

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.");

        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be Greater Than 0 ");

        if (amount > balance)
            throw new InsufficientBalanceException("Insufficient balance for this withdrawal.");

        balance -= amount;
    }

    public decimal GetBalance()
    {
        return balance;
    }
}

public class Program1
{
    public static void Main()
    {
        try
        {
            Console.Write("Enter initial balance: ");
            decimal initialBalance = Convert.ToDecimal(Console.ReadLine());
            BankAccount account = new BankAccount(initialBalance);

            Console.Write("Enter deposit amount: ");
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
            account.Deposit(depositAmount);

            Console.Write("Enter withdrawal amount: ");
            decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
            account.Withdraw(withdrawalAmount);

            Console.WriteLine("Current Balance: " + account.GetBalance());

            Console.Write("Enter another withdrawal amount: ");
            decimal anotherWithdrawalAmount = Convert.ToDecimal(Console.ReadLine());
            account.Withdraw(anotherWithdrawalAmount);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine(ex.Message);
            Console.Read();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.Read();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Console.Read();
        }
    }
}
