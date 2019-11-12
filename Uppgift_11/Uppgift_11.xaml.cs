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

namespace Uppgift_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int luck, flips, success, fails, edge;
        Random flip = new Random();

        private void ResultUpdate(int s, int f, int e)
        {
            InfoResult.Text = 
                "Antal åt rätt håll: " + s + Environment.NewLine + 
                "Antal åt fel håll: " + f + Environment.NewLine + 
                "Antal som hamnade på kanten: " + e;
        }

        public MainWindow()
        {
            InitializeComponent();
            ResultUpdate(0,0,0);
        }

        private void Luck_Click(object sender, RoutedEventArgs e)
        {
            if ((String)(sender as Button).Content == "Mer Tur") {
                VisualLuck.Value += 5;
                Lucky.Content = VisualLuck.Value + "%";
                Unlucky.Content = 100 - VisualLuck.Value + "%";
            }
            else
            {
                VisualLuck.Value -= 5;
                Lucky.Content = VisualLuck.Value + "%";
                Unlucky.Content = 100 - VisualLuck.Value + "%";
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            luck = Convert.ToInt32(VisualLuck.Value);

            for (int t = (Convert.ToInt32(NumberTries.Text)); t > 0; t--)
            {
                flips = flip.Next(100);
                if (luck > flips)
                {
                    success++;
                } else if (luck < flips)
                {
                    fails++;
                }else if (luck == flips)
                {
                    edge++;
                }
            }
            ResultUpdate(success, fails, edge);
            success = 0;
            fails = 0;
            edge = 0;
        }
    }
}
