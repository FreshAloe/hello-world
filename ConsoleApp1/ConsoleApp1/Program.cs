using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] peoples = new Person[]
            {
                new Person(51, "Anders"),
                new Person(37, "Scott"),
                new Person(45, "Peter"),
                new Person(62, "Mads"),
                new Person(28, "James")
            };

            SortPerson sortPerson = new SortPerson(peoples);
            sortPerson.Sort(AscSortByName);
            sortPerson.Display();

            Console.WriteLine();

            sortPerson.Sort(AscSortByAge);
            sortPerson.Display();
        }

        static bool AscSortByName(Person men1, Person men2)
        {
            return men1.Name.CompareTo(men2.Name) < 0;
        }

        static bool AscSortByAge(Person men1, Person men2)
        {
            return men1.Age < men2.Age;
        }
    }

    class Person
    {
        public int Age;
        public string Name;

        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public override string ToString()
        {
            return Name + ": " + Age;
        }
    }

    delegate bool CompareDelegate(Person men1, Person men2);

    class SortPerson
    {
        Person[] men;

        public SortPerson(Person[] men)
        {
            this.men = men;
        }

        public void Sort(CompareDelegate compareMethod)
        {
            Person temp;

            for(int i = 0; i < men.Length; i++)
            {
                int lowPos = i;

                for(int j = i + 1; j < men.Length; j++)
                {
                    if(compareMethod(men[j], men[lowPos]))
                    {
                        lowPos = j;
                    }
                }

                temp = men[lowPos];
                men[lowPos] = men[i];
                men[i] = temp;
            }
        }

        public void Display()
        {
            foreach(Person item in men)
            {
                Console.WriteLine(item + ", ");
            }
        }
    }
}
