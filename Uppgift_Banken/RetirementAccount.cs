using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;

namespace Uppgift_Banken
{
    class RetirementAccount : BankAccount
    {
        private readonly decimal WithdrawFee = 1.10M;

        public override bool Withdraw(decimal withdrawAmount)
        {
            if ((Balance - (withdrawAmount * WithdrawFee)) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
