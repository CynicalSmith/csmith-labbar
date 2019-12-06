using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift_Banken
{
    class SavingsAccount : BankAccount
    {
        protected override int AccountType { get; set; } = 2;

    }
}
