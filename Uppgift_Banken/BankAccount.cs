using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Uppgift_Banken
{
    public class BankAccount
    {
        public virtual decimal Balance { get; set; }
        public virtual string AccountType { get; set; }

        public virtual void Deposit(decimal i)
        {
            Balance += i;
        }

        public virtual bool Withdraw(decimal withdrawAmount)
        {
            if ((Balance - withdrawAmount) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual decimal Funds()
        {
            return Balance;
        }

        public virtual string GetAccountType()
        {
            return AccountType;
        }
        public override string ToString()
        {
            return AccountType;
        }
    }
}
