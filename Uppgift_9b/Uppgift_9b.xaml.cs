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

namespace Uppgift_9b
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool adult;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WithAdult_Checked(object sender, RoutedEventArgs e)
        {
            adult = true;
        }
        private void WithoutAdult_Checked(object sender, RoutedEventArgs e)
        {
            adult = false;
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
                Explanation.Content = "Hej " + Name.Text + "! Du är " + ageInput + " och du får se alla filmer om du kan styrka din ålder.";
            }

            if (ageInput <= 15 && adult)
            {
                if (ageInput >= 7 && ageInput <= 14)
                {
                    Explanation.Content = "Hej " + Name.Text + "! Du är " + ageInput + " och du får se alla filmer upp till åldersgränsen på 11 år eftersom du är i vuxet sällskap.";
                }
                else if (ageInput > 0 && ageInput < 7)
                {
                    Explanation.Content = "Hej " + Name.Text + "! Du är " + ageInput + " och du får se alla filmer upp till åldersgränsen på 7 år eftersom du är i vuxet sällskap.";
                }
                else
                {
                    Explanation.Content = "Skriv in en riktig ålder.";
                }
            } 

            else if (ageInput <= 15 && !adult)
            {
                if (ageInput >= 11 && ageInput <= 14)
                {
                    Explanation.Content = "Hej " + Name.Text + "! Du är " + ageInput + " och du får se alla filmer med åldergräns på 11 år.";
                }
                else if (ageInput >= 7 && ageInput <= 10)
                {
                    Explanation.Content = "Hej " + Name.Text + "! Du är " + ageInput + " och du får se alla filmer med åldergräns på 7 år.";
                }
                else if (ageInput > 0 && ageInput < 7)
                {
                    Explanation.Content = "Hej " + Name.Text + "! Du är " + ageInput + " och du får se alla barntillåtna filmer.";
                }
                else
                {
                    Explanation.Content = "Skriv in en riktig ålder.";
                }
            }
        }
    }
}
