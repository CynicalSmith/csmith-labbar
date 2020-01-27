using System;
using System.Collections.Generic;
using System.IO;
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

namespace Godiskalkylatorn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CandyCalculator cHandler = new CandyCalculator();
        List<Person> cOriginalList = new List<Person>();
        int selectedRb;

        public MainWindow()
        {
            InitializeComponent();

            if(File.Exists("CandyCalculator.bin"))
            { 
                PersonList.ItemsSource = (List<Person>)FileOperations.Deserialize("CandyCalculator.bin");
                foreach (Person p in PersonList.ItemsSource)
                {
                    cHandler.AddPerson(p);
                }
            }

            if (File.Exists("CandyCalculator_Original.bin"))
            {
                foreach (Person p in (List<Person>)FileOperations.Deserialize("CandyCalculator_Original.bin"))
                {
                    cOriginalList.Add(p);
                }
            }
        }

        private void NewPerson_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person()
            {
                Name = Name.Text,
                Age = Convert.ToInt32(Age.Text)
            };

            cHandler.AddPerson(person);
            cOriginalList.Add(person);
            PersonList.ItemsSource = null;
            PersonList.ItemsSource = cHandler.GetPeople();
        }

        private void CalculateCandies_Click(object sender, RoutedEventArgs e)
        {

            switch (selectedRb)
            {
                case 1:
                    cHandler.DivideCandyByAge(Convert.ToInt32(CandiesTotal.Text));
                    PersonList.ItemsSource = null;
                    PersonList.ItemsSource = cHandler.SortByAge();
                    break;
                case 2:
                    cHandler.DivideCandy(Convert.ToInt32(CandiesTotal.Text));
                    PersonList.ItemsSource = null;
                    PersonList.ItemsSource = cHandler.SortByName();
                    break;
                case 3:
                    cHandler.DivideCandy(Convert.ToInt32(CandiesTotal.Text));
                    PersonList.ItemsSource = null;
                    PersonList.ItemsSource = cOriginalList;
                    break;
                default:
                    cHandler.DivideCandy(Convert.ToInt32(CandiesTotal.Text));
                    PersonList.ItemsSource = null;
                    PersonList.ItemsSource = cOriginalList;
                    break;
            }
        }
        private void AgeSort_Checked(object sender, RoutedEventArgs e)
        {
            selectedRb = 1;
        }

        private void NameSort_Checked(object sender, RoutedEventArgs e)
        {
            selectedRb = 2;
        }

        private void OriginalSort_Checked(object sender, RoutedEventArgs e)
        {
            selectedRb = 3;
        }

        private void SaveList_Click(object sender, RoutedEventArgs e)
        {
            FileOperations.Serialize(PersonList.ItemsSource, "CandyCalculator.bin");
            FileOperations.Serialize(cOriginalList, "CandyCalculator_Original.bin");
        }
    }

}

