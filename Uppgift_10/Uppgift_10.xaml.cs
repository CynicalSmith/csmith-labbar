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

namespace Uppgift_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int randomNmr, guessNmr, guessCount;
        Random rngGen = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RngGenerate_Click(object sender, RoutedEventArgs e)
        {
            randomNmr = rngGen.Next(1000);
            BtnGuess.IsEnabled = true;

            // Ta bort kommentar för inbyggd dev-mode!
            // MessageBox.Show("" + randomNmr + "");

        }

        private void Guess_Click(object sender, RoutedEventArgs e)
        {
            guessNmr = Convert.ToInt32(Guess.Text);

            if (guessNmr == randomNmr)
            {
                guessCount++;
                TextOut.Text = "Du hade helt rätt! Grattis! Det tog dig " + guessCount + " gissningar att gissa rätt!";
                BtnGuess.IsEnabled = false;
                guessCount = 0;
            }
            else if ((guessNmr - 100) > randomNmr)
            {
                guessCount++;
                TextOut.Text = "Du gissade alldeles för högt.";
            }
            else if ((guessNmr + 100) < randomNmr)
            {
                guessCount++;
                TextOut.Text = "Du gissade alldeles för lågt.";
            }
            else if (guessNmr > randomNmr)
            {
                guessCount++;
                TextOut.Text = "Du gissade för högt.";
            }
            else if (guessNmr < randomNmr)
            {
                guessCount++;
                TextOut.Text = "Du gissade för lågt.";
            }
            else
            {
                guessCount++;
                TextOut.Text = "Ajdå, fortsätt gissa!";
            }
        }
    }
}
