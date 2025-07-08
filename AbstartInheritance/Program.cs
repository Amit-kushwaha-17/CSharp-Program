using System;
public interface IAccount
{
    void PayInfunds(decimal amount);
    bool WithDrawFunds(decimal amount);
    decimal GetBalance();
    string RudeLetterString();
}
public abstract class Account : IAccount
{
    private decimal balance = 0;
    public abstract string RudeLetterString();
    public virtual bool WithDrawFunds(decimal amount)
    {
        if (balance < amount)
        {
            return false;
        }
        balance -= amount;
        return true;
    }
    public void PayInfunds(decimal amount)
    {
        balance += amount;
    }
    public decimal GetBalance()
    {
        return balance;
    }
}