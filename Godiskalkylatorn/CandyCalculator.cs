using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Godiskalkylatorn
{
    class CandyCalculator : Person
    {
        public int NumberOfCandies { get; set; }
        private List<Person> People = new List<Person>();
        int tempCandies;

        public void AddPerson(Person p)
        {
            People.Add(p);
        }
        public void DivideCandy(int c)
        {
            NumberOfCandies = c / People.Count;
            tempCandies = c % People.Count;
            foreach(Person p in GetPeople())
            {
                p.Candies = NumberOfCandies;
                if (tempCandies > 0)
                {
                    tempCandies -= 1;
                    p.Candies += 1;
                }
            }
        }
        public List<Person> DivideCandyByAge(int c)
        {
            List<Person> tempListSort = new List<Person>();
            tempListSort = People.OrderBy(x => x.Age).ToList();
            NumberOfCandies = c / People.Count;
            tempCandies = c % People.Count;

            foreach (Person p in tempListSort)
                {
                p.Candies = NumberOfCandies;
                    if (tempCandies > 0)
                    {
                        tempCandies -= 1;
                        p.Candies += 1;
                    }
                }

            return tempListSort;
        }
        public List<Person> GetPeople()
        {
            return People;
        }
        public List<Person> SortByAge()
        {
            return People.OrderBy(x => x.Age).ToList();
        }
        public List<Person> SortByName()
        {
            return People.OrderBy(x => x.Name).ToList();
        }
    }
}
