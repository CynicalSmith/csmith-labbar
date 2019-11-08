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

namespace Uppgift_8
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

        char f;

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            double a, b, c;

            a = Convert.ToDouble(TalEtt.Text);
            b = Convert.ToDouble(TalTva.Text);

                if (f == '+')
                {
                    c = Math.Round((a + b), 2);
                    Summa.Text = Convert.ToString(c);

                }
                if (f == '-')
                {
                    c = Math.Round((a - b), 2);
                    Summa.Text = Convert.ToString(c);
                }
                if (f == '/')
                {
                    c = Math.Round((a / b), 2);
                    Summa.Text = Convert.ToString(c);
                }
                if (f == '*')
                {
                    c = Math.Round((a * b), 2);
                    Summa.Text = Convert.ToString(c);
                }
            }

        private void RadChk(object sender, RoutedEventArgs e)
        {
            f = Convert.ToChar((sender as RadioButton).Content);
        }
    }
}
