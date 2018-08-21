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

            SortObject sortObj = new SortObject(peoples);
            sortObj.Sort(AscSortByName);
            sortObj.Display();

            Console.WriteLine();

            sortObj.Sort(AscSortByAge);
            sortObj.Display();
        }

        static bool AscSortByName(object men1, object men2)
        {
            return ((Person)men1).Name.CompareTo(((Person)men2).Name) < 0;
        }

        static bool AscSortByAge(object men1, object men2)
        {
            return ((Person)men1).Age < ((Person)men2).Age;
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

    delegate bool CompareDelegate(object men1, object men2);

    class SortObject
    {
        object[] obj;

        public SortObject(object[] obj)
        {
            this.obj = obj;
        }

        public void Sort(CompareDelegate compareMethod)
        {
            object temp;

            for(int i = 0; i < obj.Length; i++)
            {
                int lowPos = i;

                for(int j = i + 1; j < obj.Length; j++)
                {
                    if(compareMethod(obj[j], obj[lowPos]))
                    {
                        lowPos = j;
                    }
                }

                temp = obj[lowPos];
                obj[lowPos] = obj[i];
                obj[i] = temp;
            }
        }

        public void Display()
        {
            foreach(var item in obj)
            {
                Console.WriteLine(item + ", ");
            }
        }
    }
}
