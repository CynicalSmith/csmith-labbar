using System;
using System.Collections.Generic;
using System.Text;

namespace Godiskalkylatorn
{
    [Serializable]
    class Person
    {
        public int Age { get; set; }
        public int Candies { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, ({1} år) => {2} godisar.", Name, Age, Candies);
        }
    }
}
