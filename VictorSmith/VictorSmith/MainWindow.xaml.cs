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

namespace VictorSmith
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Uppgift 1
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string eggs = TxtbNumberOfEggs.Text;
            if (eggs != "" && eggs != null)
            {
                int numberOfEggs = Int32.Parse(eggs);
                string output;
                output = string.Format("Du skall leverera {0} st kartonger till ett pris av {1} kr.", CalculateContainers(numberOfEggs).ToString(), CalculatePrice(numberOfEggs).ToString());
                TxtblOutput.Text = output;
            }
            else
            {
                MessageBox.Show("Vänligen fyll i ett giltigt värde.");
            }
        }

        public decimal CalculatePrice(int i)
        {
            decimal price = 42.72M * CalculateContainers(i);
            return price;
        }

        public int CalculateContainers(int i)
        {
            int containers = i / 12;
            return containers;
        }

        /// <summary>
        /// Uppgift 2
        /// </summary>
        int damaged, notDamaged, totalEggs;
        bool[] isBroken = new bool[] { true, true, true, false, true, false,
        false, true, true, false, true, true, false, false, true, true, false,
        true, false, false, true, false, true, true, true, true, false, false,
        false, false, false, false, false, true, false, false, true, false,
        false, true, false, true, true, true, false, true, false, true, false,
        true, true, true, false, true, false, false, false, false, false, false,
        false, false, true, false, true, false, false, true, false, false, false,
        true, true, false, false, true, true, false, true, true, false, false,
        true, true, true, false, false, false, false, true };

        private void BtnBrokenEggs_Click(object sender, RoutedEventArgs e)
        {
            
            //MessageBox.Show(isBroken.Count().ToString()); Kontroll att antal ägg är korrekt.
            MessageBox.Show(BrokenEggs());
            CountEggs(123);
        }

        public string BrokenEggs()
        {
            foreach (bool brokenEgg in isBroken)
            {
                totalEggs++;
                if (brokenEgg == true)
                {
                    damaged += 1;
                }
                else
                {
                    notDamaged += 1;
                }
            }
            return string.Format("Av {0} är det {1} som är trasiga och {2} som är hela.", totalEggs, damaged, notDamaged);
        }

        /// <summary>
        /// Uppgift 3
        /// </summary>
        List<string> pinkCodes = new List<string>() {"1SE123-2", "0SE675-6",
        "2SE122-4", "0SE234-1", "0SE234-5", "2SE564-4", "0SE234-2", "1SE564-6",
        "2SE144-5", "0SE675-1", "1SE144-1", "2SE144-3", "1SE123-4", "2SE122-2",
        "1SE122-6", "0SE234-2", "2SE123-3", "1SE234-3", "1SE123-6", "1SE123-4",
        "0SE122-2", "1SE144-3", "0SE234-4", "0SE564-1", "0SE234-4", "2SE144-3",
        "2SE122-3", "1SE234-3", "1SE123-4", "1SE564-5", "1SE123-1", "2SE122-6",
        "0SE123-6", "1SE564-6", "1SE234-5", "1SE564-6", "2SE234-2", "1SE234-3",
        "0SE234-3", "2SE122-5", "2SE234-2", "2SE144-2", "2SE564-5", "1SE144-5",
        "1SE675-4", "1SE123-6", "2SE564-6", "1SE122-6", "1SE122-5", "2SE122-2",
        "1SE234-2", "0SE675-5", "2SE122-4", "1SE234-6", "0SE564-4", "1SE564-6",
        "2SE675-3", "1SE144-4", "2SE564-5", "0SE564-1", "1SE564-4", "1SE123-4",
        "1SE564-6", "2SE122-2", "1SE564-5", "2SE234-4", "1SE564-4", "2SE122-1",
        "2SE123-3", "2SE564-2", "2SE234-4", "1SE144-1", "1SE675-1", "0SE144-1",
        "2SE123-6", "0SE123-5", "2SE144-6", "0SE144-6", "1SE122-4", "1SE675-6",
        "0SE122-6", "2SE144-2", "2SE122-3", "1SE234-5", "1SE564-2", "1SE144-5",
        "0SE144-1", "1SE144-3", "1SE122-4", "1SE123-1"};
        public int CountEggs(int farmerEggs)
        {
            int nmbrFarmerEggs = 0;
            foreach (string pinkMatch in pinkCodes)
            {
                if (pinkMatch.Contains(farmerEggs.ToString()))
                {
                    nmbrFarmerEggs++;
                }
            }
            return nmbrFarmerEggs;
        }

        /// <summary>
        /// Uppgift 4 & 5
        /// </summary>
        private void BtnAddHen_Click(object sender, RoutedEventArgs e)
        {
            HenHouse henHouse = new HenHouse(250);
            LayEgg();
        }

        /// <summary>
        /// Uppgift 6
        /// </summary>

        /*
        * Lägger metoden här för att då kommer jag kunna
        * kalla på den varifrån jag vill. Kallas just nu
        * ifrån BtnAddHen_Click
        */
        public int LayEgg()
        {
            int laidEgg = 0;
            Random random = new Random(); // Syntax för specifik range: https://stackoverflow.com/questions/3975290/produce-a-random-number-in-a-range-using-c-sharp
            for (int q = 0; q < 365; q++)
            {
                if (random.Next(0, 101) <= 48)
                {
                    laidEgg++;
                }
            }
            return laidEgg;
        }

        /// <summary>
        /// Uppgift 7
        /// </summary>

        /*
        * Skapar metoden EggsInBasket()
        * indata är av typen antal Hens från HenHouse för att då kunna loopa igenom alla hönor med LayEgg()
        * Utdata blir en decimal för detta kan jag då presentera som antal ägg som värpts idag
        */
        private void BtnEggsInBasket_Click(object sender, RoutedEventArgs e)
        {
            HenHouse henHouse = new HenHouse(250);
            EggsInBasket(henHouse);
        }

        decimal EggsInBasket(HenHouse henhouse)
        {
            decimal totalEggsInBasketToday = 0;
            foreach(Hen hen in henhouse.Hens)
            {
                totalEggsInBasketToday += LayEgg();
            }
            totalEggsInBasketToday /= 365;
            totalEggsInBasketToday = Math.Floor(totalEggsInBasketToday);
            return totalEggsInBasketToday;
        }

        /// <summary>
        /// Uppgift 8
        /// </summary>
        private void BtnLayEggTwo_Click(object sender, RoutedEventArgs e)
        {
            LayEgg2();
            LayEgg3(5);
        }

        Egg LayEgg2()
        {
            Random random = new Random(); // Syntax för specifik range: https://stackoverflow.com/questions/3975290/produce-a-random-number-in-a-range-using-c-sharp
            Egg egg = new Egg();
            int k = 0;
            while (k != 1) //Lade till för att garantera åtminstone 1 resultat per knapptryck.
            {
                if (random.Next(0, 101) <= 48)
                {
                    egg.Weight = random.Next(20, 81);
                    k++;
                }
                else
                {
                    return null;
                }
            }
            return egg;
        }

        /// <summary>
        /// Uppgift 9
        /// </summary>
        List<Egg> LayEgg3(int i)
        {
            Egg eggList = new Egg();
            Random random = new Random();
            
            for(int k = 0; k <= i; k++)  //Lade till för att samla en lista på x antal för att testa så det fungerar.
            {
                if (random.Next(0, 101) <= 48) // Inspiration from LayEgg()
                {
                    Egg egg = new Egg()
                    {
                        Weight = random.Next(20, 81)
                    };
                    eggList.CollectEggs(egg);
                    k++;
                }
                //Valde att skippa return null; eftersom jag inte fick det att fungera.
                //Varje gång som if-satsen inte var sann så hoppade den till return null; som bröt loopen för att samla in data.
                //För att returnera att ett ägg inte blev till så fungerar null som det skall dock.
            }
        return eggList.CollectedEggs;
        }

        /// <summary>
        /// Uppgift 10
        /// </summary>
        Egg classificationEgg = new Egg();
        private void BtnClassify_Click(object sender, RoutedEventArgs e)
        {
            string weightInput = TxtbNumberOfEggs.Text;
            MessageBox.Show(classificationEgg.GetClassification(weightInput));
        }
    }
}
