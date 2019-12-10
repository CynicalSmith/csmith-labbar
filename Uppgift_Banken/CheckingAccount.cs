using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift_Banken
{
    class CheckingAccount : BankAccount
    {
        private decimal Credit { get; set; }
        public decimal MaxCredit { get; private set; }

        public override bool Withdraw(decimal withdrawAmount)
        {
            if ((Credit + Balance - withdrawAmount) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Deposit(decimal i)
        {
            if (Credit < MaxCredit && Balance <= 0)
            {
                Credit = MaxCredit % i;
                if (MaxCredit % i > 0)
                {
                    Balance += MaxCredit % i;
                }
            } 
            
            else if (Credit >= MaxCredit)
            {
                Balance += i;
            }

        }
        public override decimal Funds()
        {
            return Balance + Credit;
        }

        public decimal SetCredit(decimal c)
        {
            Credit += c;
            return Credit;
        }

        public decimal SetMaxCredit(decimal c)
        {
            MaxCredit = c;
            Credit = MaxCredit;
            return MaxCredit;
        }
        public decimal GetCredit()
        {
            return Credit;
        }
    }
}
