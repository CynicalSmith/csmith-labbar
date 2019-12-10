using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift_Banken
{
    public class Customer
    {
        public int AccountID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cellphone { get; set; }
        public string Address { get; set; }
        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public void SetAccountID(int i)
        {
            AccountID = i;
        }

        public List<Customer> GetCustomers()
        {
            return Customers;
        }

        public void AddCustomer(Customer c)
        {
            Customers.Add(c);
        }

        public override string ToString()
        {
            return string.Format("{1}, {0}", FirstName, LastName);
        }
    }
}
