using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorSmith
{
    class Egg
    {
        public int Weight { get; set; } //Konflikt mellan vikt på hönan och vikt på ägget.
        public List<Egg> CollectedEggs { get; set; } = new List<Egg>();

        public List<Egg> CollectEggs(Egg egg)
        {
            CollectedEggs.Add(egg);
            return CollectedEggs;
        }

        public string GetClassification(string Weight)
        {
            string classification = ""; //Fick "Use of unassigned local variable 'classification' utan = ""
            if (Weight != "" && Weight != null)
            {
                int weightOfEgg;
                weightOfEgg = Int32.Parse(Weight);
                if (weightOfEgg >= 20 && weightOfEgg <= 39)
                {
                    classification = "S";

                }
                else if (weightOfEgg > 39 && weightOfEgg <= 59)
                {
                    classification = "L";

                }
                else if (weightOfEgg >= 60 && weightOfEgg <= 80)

                {
                    classification = "XL";

                } else
                {
                    MessageBox.Show("Vänligen fyll i ett giltigt värde.");

                }
            }
            else
            {
                MessageBox.Show("Vänligen fyll i ett giltigt värde.");
                return null;
            }
            return string.Format("Ägget klassifieras som: {0} och väger {1} gram.", classification, Weight);
        }
    }
}
