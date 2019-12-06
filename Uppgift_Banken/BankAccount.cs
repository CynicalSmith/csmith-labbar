using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Uppgift_Banken
{
    abstract class BankAccount
    {
        public virtual decimal Balance { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
        protected virtual int AccountType { get; set; }


        public virtual decimal Deposit(decimal i)
        {
            Balance += i;
            return Balance;
        }

        public virtual bool Withdraw(decimal withdrawAmount)
        {
            if ((Balance - withdrawAmount) > 0)
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

        public int ReturnAccountType()
        {
            return AccountType;
        }
    }
}
