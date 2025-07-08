using System;
public interface Iaccount
{
    void PayinFund(decimal amount);
    bool WithdrawFund(decimal amount);
    decimal GetBalance();
    decimal amounts();
}
public class CustomerAccount : Iaccount
{
    private  decimal balance = 0;
    public virtual bool WithdrawFund(decimal amount)
    {
        if (amount > balance)
        {
            return false;
        }
        balance -= amount;
        return true;
    }
    public void PayinFund(decimal amount)
    {
        balance += amount;
    }
    public decimal GetBalance()
    {
        return balance;
    }
     public  decimal amounts()
        {
            decimal amnt = 0;
            try
            {
                Console.Write("Enter amount ");
                string stringamount = Console.ReadLine();
                return amnt = decimal.Parse(stringamount);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return amnt;
            }
        }
   
}
    public class BabyAccount : CustomerAccount, Iaccount
    {
        public override bool WithdrawFund(decimal amount)
        {
            if (amount > 10)
            {
                return false;
            }
            return base.WithdrawFund(amount);
        }
    }
public class bank
{
        const int MAX_CUST = 100;


    public static void Main()
    {
        Iaccount[] accounts = new Iaccount[MAX_CUST];
        accounts[0] = new CustomerAccount();
        accounts[0].PayinFund(accounts[0].amounts());
        if (accounts[0].WithdrawFund(accounts[0].amounts()))
        {
            Console.WriteLine("Your Current Balance is " + accounts[0].GetBalance());
        }
        else
        {
            Console.WriteLine("Cannot Withdraw ");
        }

        accounts[1] = new BabyAccount();
        accounts[1].PayinFund(accounts[1].amounts());
        if (accounts[1].WithdrawFund(accounts[1].amounts()))
        {
            Console.WriteLine("Your Current Balance is " + accounts[0].GetBalance());
        }
        else
         {
            Console.WriteLine("Cannot Withdraw ");
        }

    }
}
