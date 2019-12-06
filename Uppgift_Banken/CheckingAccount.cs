using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift_Banken
{
    class CheckingAccount : BankAccount
    {
        private decimal Credit { get; set; }
        protected override int AccountType { get; set; } = 1;

        public override bool Withdraw(decimal withdrawAmount)
        {
            if ((Credit + Balance - withdrawAmount) > 0)
            {
                Balance -= withdrawAmount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override decimal Deposit(decimal i)
        {
            if (Credit < 0)
            {
                i += Credit;
                Credit -= Credit;
                Balance += i;
            }
            else
            {
                Balance += i + Credit;
            }
            return Balance;
        }
        public override decimal Funds()
        {
            return (Balance + Credit);
        }

        public decimal ChangeCredit(decimal c)
        {
            Credit += c;
            return Credit;
        }
    }
}
