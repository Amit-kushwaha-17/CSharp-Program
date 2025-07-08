using System;
//1. getting name and balance method for interface
public interface IAccount
{
    string GetName();
    decimal GetBalance();
}

//2. Inheritance Interface Account
public class CustomerAccount : IAccount
{
    private string name;
    private decimal balance;
    //3. Make constructor to get value of name balance as parameter
    public CustomerAccount(string name, decimal balance)
    {
        this.name = name;
        this.balance = balance;
    }
    //4 return name and balance and implimentation of Interface
    public string GetName()
    {
        return name;
    }
    public decimal GetBalance()
    {
        return balance;
    }
}
//5. Making Bank interface for finding Account by name and store the reference of CustomerAccont
public interface IBank
{
    IAccount findAccount(string name);
    bool StoreAccount(IAccount account);
}
public class ArrayBank : IBank
{
    private IAccount[] accounts; //6 Making Array of IAccount interface
    //7. Making Array Bank Constructor to Get Size of accounts instance 
    public ArrayBank(int Banksize)
    {
        accounts = new IAccount[Banksize];
    }
    public bool StoreAccount(IAccount account)
    {
        for (int i = 0; i < accounts.Length; i++)
        {
            if (accounts[i] == null)
            {
                accounts[i] = account;
                return true;
            }
        }
        return false;
    }
    public IAccount findAccount(string name)
    {
        for (int i = 0; i < accounts.Length; i++)
        {
            if (accounts[i] == null)
                continue;

            if (accounts[i].GetName() == name)
            {
                return accounts[i];
            }
        }
        return null;
    }
}
public class BankProgram
{
    public static void Main()
    {
        IBank ourBank = new ArrayBank(100);
        IAccount newAccount = new CustomerAccount("Rob", 10000);

        if (ourBank.StoreAccount(newAccount))
        {
            Console.WriteLine("Account Stored SuccessFully");
        }

        IAccount StoredAccount = ourBank.findAccount("Rob");
        if (StoredAccount != null)
        {
            Console.WriteLine($"Account found \nName:  {StoredAccount.GetName()}\nBalance: {StoredAccount.GetBalance()}");
        }
        else
        {
            Console.WriteLine("Account not Found");
        }
    }
}
