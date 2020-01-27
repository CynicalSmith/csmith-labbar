using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Uppgift_Banken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> allCustomers = new List<Customer>();
        private Customer activeCustomer = new Customer();
        List<BankAccount> activeBankAccounts = new List<BankAccount>();
        BankAccount activeAccount;// = new BankAccount();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Kod för att välja kund i ComboBoxen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BtnSelectCustomer_Click(object sender, RoutedEventArgs e)
        {
            activeCustomer = CboCustomer.SelectedItem as Customer;
            activeBankAccounts = activeCustomer.BankAccounts;
            CboSelectAccount.ItemsSource = null;
            CboSelectAccount.ItemsSource = activeCustomer.BankAccounts;
            CboSelectAccount.SelectedIndex = 0;
        }

        /// <summary>
        /// Kod för att välja konto från aktiv kund
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectAccount_Click(object sender, RoutedEventArgs e)
        {
            activeAccount = CboSelectAccount.SelectedItem as BankAccount;
        }

        /// <summary>
        /// Insättningar och uttag från valt bankkonto = en transaktion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveTransaction_Click(object sender, RoutedEventArgs e)
        {
            decimal amount = Convert.ToDecimal(TxtAmount.Text);

            if (OptDeposit.IsChecked == true)
            {
                activeAccount.Deposit(amount);

            } else if (OptWithdrawal.IsChecked == true)
            {
                if (activeAccount.Withdraw(amount) && activeAccount.AccountType.Equals("Pensionsspar"))
                {
                    activeAccount.Balance -= amount * 1.1M;
                } 
                
                else if (activeAccount.Withdraw(amount) && activeAccount.AccountType.Equals("Lönekonto"))
                {

                    if (activeAccount.Balance >= amount)
                    {
                        activeAccount.Balance -= amount;
                    }

                    else
                    {
                        amount -= activeAccount.Balance % amount;
                        activeAccount.Balance = 0;
                        (activeAccount as CheckingAccount).SetCredit(-amount);
                    }
                }

                else if (activeAccount.Withdraw(amount))
                {
                        activeAccount.Balance -= amount;
                }

                else if (activeAccount.Withdraw(amount) || activeAccount.AccountType == "Pensionsspar")
                {
                    MessageBox.Show(string.Format("Du kan inte ta ut {0} kr eftersom du har {1} kr på kontot och uttagskostnaden är 10% av uttagsbeloppet. " +
                        "Vänligen sätt in {2} kr eller välj en annan summa.",
                        amount,
                        activeAccount.Funds(),
                        ((amount * 1.1M) - activeAccount.Funds())));
                } 
                
                else if (activeAccount.Withdraw(amount) || !activeAccount.AccountType.Equals("Pensionsspar"))
                {
                    MessageBox.Show(string.Format("Du kan inte ta ut {0} kr eftersom du har {1} kr på kontot. " +
                        "Vänligen sätt in {2} kr eller välj en annan summa.",
                        amount,
                        activeAccount.Funds(),
                        (amount - activeAccount.Funds())));
                }
            }
            LstTransactions.Items.Clear();
            LstTransactions.Items.Add(string.Format("Saldo: {0}", activeAccount.Funds()));
        }

        /// <summary>
        /// Skapa ny kund
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            
            Customer customer = new Customer()
            {
                FirstName = TxtFirstname.Text,
                LastName = TxtLastname.Text,
                Cellphone = TxtPhone.Text
            };

            allCustomers.Add(customer);
            activeCustomer = customer;
            CboCustomer.ItemsSource = allCustomers;
        }

        /// <summary>
        /// Skapa nytt bankkonto till aktiv kund
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewAccount_Click(object sender, RoutedEventArgs e)
        {
            if (OptChecking.IsChecked == true)
            {
                CheckingAccount bank = new CheckingAccount()
                {
                    Balance = 0,
                    AccountType = "Lönekonto"
                };
                if (!TxtCredit.Text.Equals(""))
                {
                    bank.SetMaxCredit(Convert.ToDecimal(TxtCredit.Text));
                    AddAccount(bank);

                } else
                {
                    MessageBox.Show("Du måste fylla i ett giltigt värde för krediten.");
                }

                TxtCredit.Clear();

            } else if (OptSavings.IsChecked == true)
            {
                SavingsAccount bank = new SavingsAccount()
                {
                    Balance = 0,
                    AccountType = "Sparkonto"
                };

                activeCustomer.BankAccounts.Add(bank);
                CboSelectAccount.ItemsSource = null;
                CboSelectAccount.ItemsSource = activeCustomer.BankAccounts;

            } else if (OptRetirement.IsChecked == true)
            {
                RetirementAccount bank = new RetirementAccount()
                {
                    Balance = 0,
                    AccountType = "Pensionsspar"
                };

                activeCustomer.BankAccounts.Add(bank);
                CboSelectAccount.ItemsSource = null;
                CboSelectAccount.ItemsSource = activeCustomer.BankAccounts;
            }
            activeBankAccounts = activeCustomer.BankAccounts;
            CboSelectAccount.SelectedIndex = 0;
            activeAccount = CboSelectAccount.SelectedItem as BankAccount;
        }

        private void CboCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void AddAccount(BankAccount b)
        {
            activeCustomer.BankAccounts.Add(b);
            CboSelectAccount.ItemsSource = null;
            CboSelectAccount.ItemsSource = activeCustomer.BankAccounts;
        }
    }
}
