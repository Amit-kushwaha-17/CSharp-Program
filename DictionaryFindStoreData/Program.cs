using System;

public interface IAccount
{
    string GetName();
    Decimal GetBalance();
}
public class CustomerAccount : IAccount
{
    private string name;
    private decimal balance;
    public CustomerAccount(string name, decimal balance)
    {
        this.name = name;
        this.balance = balance;
    }
    public string GetName()
    {
        return name;
    }
    public decimal GetBalance()
    {
        return balance;
    }
}
public class BankDictionary
{
    Dictionary<string, IAccount> AccountDictionary = new Dictionary<string, IAccount>();

    public IAccount FindAccount(String name)
    {
        if (AccountDictionary.ContainsKey(name))
        {
            return AccountDictionary[name];
        }
        return null;
    }
    public bool StoreAccount(IAccount account)
    {
        if (AccountDictionary.ContainsKey(account.GetName()))
        {
            return false;
        }
        else
        {
            AccountDictionary.Add(account.GetName(), account);
            return true;
        }
    }
}
public class BankProgram()
{
    public static void Main()
    {
        IAccount StoredData = new CustomerAccount("Amit", 100000);
        BankDictionary GetStore = new BankDictionary();
        if (GetStore.StoreAccount(StoredData))
        {
            Console.WriteLine("Account Created In the Bank");
        }
        else
        {
            Console.WriteLine("Account Store Failed");
        }
        IAccount FoundAccount = GetStore.FindAccount("Amit");
        if (FoundAccount != null)
        {
            Console.WriteLine("Account Found");
            Console.WriteLine("Name : " + FoundAccount.GetName());
            Console.WriteLine("Balance : " + FoundAccount.GetBalance());

        }
        else
        {
            Console.WriteLine("Storing Account Failed");
        }
    }
}