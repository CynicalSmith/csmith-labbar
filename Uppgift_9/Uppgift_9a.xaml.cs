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

namespace Uppgift_9a
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

        private void BtnClk(object sender, RoutedEventArgs e)
        {
            int ageInput;

            ageInput = int.Parse(Age.Text);
            
            if (ageInput >= 16)
            {
                Explanation.Content = "Hej " + Name.Text + "! Du är " + ageInput + " och du får se alla filmer.";
            }
            else if (ageInput == 15)
            {
                Explanation.Content = "Hej " + Name.Text + "! Du är " + ageInput + " och du får se alla filmer om du kan styrka detta.";
            }
            else if (ageInput >= 11 && ageInput <= 14)
            {
                Explanation.Content = "Hej " + Name.Text + "! Du är " + ageInput + " och du får se alla filmer upp till åldersgränsen på 11 år.";
            }
            else if (ageInput >= 7 && ageInput <= 10)
            {
                Explanation.Content = "Hej " + Name.Text + "! Du är " + ageInput + " och du får se alla filmer upp till åldersgränsen på 11 år om du är i vuxet sällskap.";
            }
            else if (ageInput < 7)
            {
                Explanation.Content = "Hej " + Name.Text + "! Du är " + ageInput + " och du får se alla barntillåtna filmer.";
            }
        }

    }
}
