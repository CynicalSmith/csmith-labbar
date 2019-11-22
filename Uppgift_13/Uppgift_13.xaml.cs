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

namespace Uppgift_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string checkSearchLength;
        char[] textToSearch;
        int i, a;
        char textQuery;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LetterSearching(char[] t)
        {
            if (checkSearchLength.Length != 1)
            {
                textQuery = ' ';
            }
            else
            {

            textQuery = Convert.ToChar(LetterSearch.Text.ToLower());

                foreach (char c in t)
                {
                    if (t[i] == textQuery)
                    {
                        a++;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private void CheckSearchLength(string s)
        {
            if(s.Length > 1)
            {
                MessageBox.Show("Du kan bara jämföra en bokstav åt gången.");
                LetterSearch.Text = "";
                a = 0;
            }
        }

        private void BtnCount_Click(object sender, RoutedEventArgs e)
        {
            a = 0;
            i = 0;

            checkSearchLength = LetterSearch.Text;
            CheckSearchLength(checkSearchLength);
            textToSearch = TextInputText.Text.ToLower().ToCharArray();
            LetterSearching(textToSearch);
            NumberOfLetters.Content = String.Format("Antal gånger som {0} finns med i texten: {1}.", LetterSearch.Text.ToUpper(), a);
        }
    }
}
