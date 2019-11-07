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

namespace Uppgift_6
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

        private void ClearAllForm()
        {
            InputOne.Clear();
            InputTwo.Clear();
            SumTotal.Clear();
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            if(Convert.ToString((sender as Button).Content) != "Rensa")
            {
                double a, b, c;
                char f;

                a = Convert.ToDouble(InputOne.Text);
                b = Convert.ToDouble(InputTwo.Text);

                f = Convert.ToChar((sender as Button).Content);
                if (InputOne.Text.Contains(',') || InputTwo.Text.Contains(','))
                {
                    MessageBox.Show("Använd inte komma, använd punkt.");
                    ClearAllForm();
                }
                else
                {
                    if (f == '+')
                    {
                        c = Math.Round((a + b), 2);
                        SumTotal.Text = Convert.ToString(c);

                    }
                    if (f == '-')
                    {
                        c = Math.Round((a - b), 2);
                        SumTotal.Text = Convert.ToString(c);
                    }
                    if (f == '/')
                    {
                        c = Math.Round((a / b), 2);
                        SumTotal.Text = Convert.ToString(c);
                    }
                    if (f == '*')
                    {
                        c = Math.Round((a * b), 2);
                        SumTotal.Text = Convert.ToString(c);
                    }


                }
                

            }
            else
            {
                ClearAllForm();
            }

            }
        }
    }

