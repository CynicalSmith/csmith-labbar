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

namespace Uppgift_14
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

        string inputText;
        int i;

        private void AllocateParameters()
        {
            i = 0;
            inputText = NumbersInput.Text;

        }

        private bool CheckNumbers(string t)
        {
            foreach (char c in t)
            {
                if (char.IsDigit(c))
                {
                    i++;
                    if (i == 4)
                    {
                        CheckValidLength(t);
                    }
                }
                else
                {
                    MessageBox.Show(String.Format("Du får bara sätta in siffror. {0} är inte en siffra, vänligen ta bort den.", char.ToUpper(c)));
                    return false;
                }
            }
            return false;
        }

        private bool CheckValidLength(string t)
        {
            if (t.Length == 4)
            {
                int j = Convert.ToInt32(t);
                MessageBox.Show(String.Format("Du är {0} år gammal.", Convert.ToString(CalcualteAge(j))));
            }
            else
            {
                MessageBox.Show(String.Format("Du måste mata in minst 4 siffror. Du har matat in {0} siffror.", t.Length));
                return false;
            }
            return false;
        }

        private int CalcualteAge(int q)
        {
            return DateTime.Now.Year - q;
        }

        private void BtnNumbersCalculate_Click(object sender, RoutedEventArgs e)
        {
            AllocateParameters();
            CheckNumbers(inputText);
        }
    }
}
