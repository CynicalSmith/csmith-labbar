using System;

using System.Threading;

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

namespace Uppgift_12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<int> valuesIn = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateNumbers()
        {
            foreach (int item in valuesIn)
            {
                    valuesDisplay.Text = String.Join(Environment.NewLine, valuesIn);
            }
        }

        private void UpdateAverage()
        {
            double b = 0.00;
            for (int a = 0; a <= valuesIn.Count-1; a++)
            {
                b += Convert.ToInt32(valuesIn[a]);
            }

            b = Math.Round(b / valuesIn.Count, 2);
            averageOut.Text = b.ToString();
        }
        
        private void CalculateValue_Click(object sender, RoutedEventArgs e)
        {
            if (valuesIn.Count >= 5)
            {
                valuesIn.RemoveRange(0, 1);
            }
            valuesIn.Add(Convert.ToInt32(valuesInput.Text));
            UpdateNumbers();
            UpdateAverage();
        }
    }
}
