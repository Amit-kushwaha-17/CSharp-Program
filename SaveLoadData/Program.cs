using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
public interface IAccount
{
    void PayInFund(decimal amount);
    bool WithDrawFund(decimal amount);
    decimal GetBalance();
    string GetName();
    bool SaveFile(string filename);
}
public class CustomerAccount : IAccount
{
    private string name;
    private decimal balance = 0;
    public CustomerAccount(string name, decimal balance)
    {
        this.name = name;
        this.balance = balance;
    }
    public bool WithDrawFund(decimal amount)
    {
        if (amount > balance)
        {
            return false;
        }
        balance -= amount;
        return true;
    }
    public void PayInFund(decimal amount)
    {
        balance += amount;
    }
    public string GetName()
    {
        return name;
    }
    public decimal GetBalance()
    {
        return balance;
    }
    public bool SaveFile(string filename)
    {
        try
        {
            TextWriter textOut = new StreamWriter(filename);
            textOut.WriteLine(name);
            textOut.WriteLine(balance);
            textOut.Close();
        }
        catch
        {
            return false;
        }
        return true;
    }
    public static CustomerAccount Load(string filename)
    {
        CustomerAccount result = null;
        TextReader TextIn = null;
        try
        {
            TextIn = new StreamReader(filename);
            string TextName = TextIn.ReadLine();
            string TextBalance = TextIn.ReadLine();
            decimal balance = decimal.Parse(TextBalance);
            result = new CustomerAccount(TextName, balance);
        }
        catch
        {
            return null;
        }
        finally
        {
            if (result != null)
            {
                TextIn.Close();
            }
        }
        return result;

    }
}
public class bank
{
    public static void Main()
    {
        IAccount amitacc = new CustomerAccount("Amit", 100000);
        if (amitacc.SaveFile("Customer.txt"))
        {
            Console.WriteLine("Account Saved SuccessFully");
        }
        else
        {
            Console.WriteLine("Account Could not Save ");
        }
        amitacc = CustomerAccount.Load("Customer.txt");
        Console.WriteLine("Name : " + amitacc.GetName());
        Console.WriteLine("Balance : " + amitacc.GetBalance());
        if (amitacc == null)
        {
            Console.WriteLine("Code Failed to Load");
        }
        else
        {
            Console.WriteLine("File Load Successfully");
        }
        
    }
}