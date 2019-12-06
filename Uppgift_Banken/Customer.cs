using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift_Banken
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Cellphone { get; set; }
        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public string Address { get; set; }

    }
}
