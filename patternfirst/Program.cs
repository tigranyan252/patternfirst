using System;

public interface IBankAccount
{
    void Withdraw(decimal amount);
    decimal GetBalance();
}

public class RealBankAccount : IBankAccount
{
    private decimal balance;

    public RealBankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Недостаточно средств на счете");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"Снято {amount} со счета. Остаток: {balance}");
        }
    }

    public decimal GetBalance()
    {
        return balance;
    }
}

public class BankCheckProxy : IBankAccount
{
    private RealBankAccount realAccount;

    public BankCheckProxy(decimal initialBalance)
    {
        realAccount = new RealBankAccount(initialBalance);
    }

    public void Withdraw(decimal amount)
    {
        realAccount.Withdraw(amount);
    }

    public decimal GetBalance()
    {
        return realAccount.GetBalance();
    }
}

class Program
{
    static void Main()
    {
        IBankAccount bankAccount = new BankCheckProxy(1000);

        bankAccount.Withdraw(500);
        decimal balance = bankAccount.GetBalance();
        Console.WriteLine($"Остаток на счете: {balance}");
    }
}