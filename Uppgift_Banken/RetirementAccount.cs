using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;

namespace Uppgift_Banken
{
    class RetirementAccount : BankAccount
    {
        private readonly decimal WithdrawFee = 1.10M;
        protected override int AccountType { get; set; } = 3;

        public override bool Withdraw(decimal withdrawAmount)
        {
            if ((Balance - (withdrawAmount * WithdrawFee)) > 0)
            {
                Balance -= (withdrawAmount * WithdrawFee);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
