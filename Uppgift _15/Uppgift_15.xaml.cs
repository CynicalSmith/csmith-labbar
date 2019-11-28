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

namespace Uppgift__15
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

        string toTranslateTemp, translatedTextTemp, translatedTextOut, totalVowelsOut;
        char[] vowels = new char[9] { 'A', 'E', 'I', 'O', 'U', 'Y', 'Å', 'Ä', 'Ö' };
        char[] toTranslate;
        int totalVowels;

        private void AllocateParameters()
        {
            toTranslateTemp = textInput.Text;
            toTranslate = toTranslateTemp.ToCharArray();
            translatedTextTemp = "";
            translatedTextOut = "";
            totalVowels = 0;
        }

        private int NumberOfVowels(char[] i)
        {
            foreach (char c in i)

                if (IsVowel(c) && Char.IsUpper(c))
                {
                    totalVowels++;
                } else if (IsVowel(c) && Char.IsLower(c))
                {
                    totalVowels++;
                } else
                {
                    return c;
                }

            return totalVowels;
        }

        private string Jibberish(string c, char e)
        {
            translatedTextTemp = (translatedTextTemp + e + c + e);
            return c;
        }

        private bool IsVowel(char c)
        {
            for (int i = 0; i < vowels.Length; i++)
            {
                if (Char.ToUpper(c) == vowels[i])
                {
                    return true;
                }
            }
            return false;
        }

        private string TranslateText(char[] s)
        {
            foreach (char c in s)
            {
                if (IsVowel(c) && Char.IsUpper(c))
                {
                    Jibberish(c.ToString(), 'Ö');
                }
                else if (IsVowel(c) && Char.IsLower(c))
                { 
                    Jibberish(c.ToString(), 'ö');
                } else
                {
                    translatedTextTemp = translatedTextTemp + c;
                }
            }
            return translatedTextTemp;
        }

        private void BtnTranslate_Click(object sender, RoutedEventArgs e)
            {
            AllocateParameters();
            NumberOfVowels(toTranslate);
            TranslateText(toTranslate);
            translatedTextOut = translatedTextTemp;
            totalVowelsOut = String.Format("Antal vokaler: {0}", totalVowels);
            numberOfVowels.Content = totalVowelsOut;
            textOutput.Text = translatedTextOut;
            }
        }
    }
