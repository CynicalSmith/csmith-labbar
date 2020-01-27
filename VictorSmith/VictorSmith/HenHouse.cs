using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorSmith
{
    class HenHouse : Hen
    {
        public List<Hen> Hens = new List<Hen>();


        public HenHouse(int i)
        {
            int k = 0;
            Hen hen = new Hen();

            while(k < i)
            {
                Hens.Add(hen);
                k++;
            }
        }
    }
}
