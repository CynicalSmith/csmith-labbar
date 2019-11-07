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

namespace Uppgift_5
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

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString((sender as Button).Content) != "Rensa")
            {
                if (!int.TryParse(InputOne.Text, out int i) || !int.TryParse(InputTwo.Text, out int k)) {
                       MessageBox.Show("Använd bara siffror tack.");
                        InputOne.Clear();
                        InputTwo.Clear();
                        TotalSum.Clear();
                } else { 
                    string a, b;
                    int c;
                        a = InputOne.Text;
                        b = InputTwo.Text;
                        c = Convert.ToInt32(a) + Convert.ToInt32(b);
                            TotalSum.Text = Convert.ToString(c);
                }
            } else
            {
                InputOne.Clear();
                InputTwo.Clear();
                TotalSum.Clear();
            }
        }
    }
}
