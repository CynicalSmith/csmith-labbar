using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Uppgift_Banken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        CheckingAccount checking = new CheckingAccount() { Balance = 100 };
        SavingsAccount saving = new SavingsAccount() { Balance = 250 };
        RetirementAccount retire = new RetirementAccount() { Balance = 500 };
        Customer person = new Customer()
        {
            Address = "Östersund",
            FirstName = "Victor",
            LastName = "Smith",
            Cellphone = 0700000000
        };

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            checking.ChangeCredit(-150);

            checking.Deposit(200);

            if (checking.Withdraw(100))
            {
                MessageBox.Show("Lyckades");
            }
            else if (!checking.Withdraw(500))
            {
                MessageBox.Show("Misslyckades");
            }

            MessageBox.Show(checking.Funds().ToString());
            person.BankAccounts.Add(checking);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(saving.ReturnAccountType().ToString());
            person.BankAccounts.Add(saving);
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            retire.Withdraw(250);
            MessageBox.Show(retire.Funds().ToString());
            person.BankAccounts.Add(retire);
        }
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(person.BankAccounts.Count().ToString());
        }
    }
}
