using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ArrayListSample
{
    class Person : IComparable
    {
        public int age;
        public string name;

        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public override string ToString()
        {
            return string.Format("{0, 5} {1, -10}", age, name);
        }

        public int CompareTo(object a)
        {
            Person man1 = a as Person;

            if (this.age < man1.age) return -1;
            else if (this.age == man1.age) return 0;

            return 1;
        }
    }

    class PersonCompareAsc : IComparer
    {
        public int Compare(object a, object b)
        {
            Person man1 = a as Person;
            Person man2 = b as Person;

            if (man1.age > man2.age) return -1;
            else if (man1.age == man2.age) return 0;

            return 1;
        }
    }

    class PersonCompareDesc : IComparer
    {
        public int Compare(object a, object b)
        {
            Person man1 = a as Person;
            Person man2 = b as Person;

            if (man1.age < man2.age) return -1;
            else if (man1.age == man2.age) return 0;

            return 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList ar = new ArrayList();
            Person man1 = new Person(36, "Anderson");
            Person man2 = new Person(30, "Neo");
            Person man3 = new Person(49, "FreshAloe");
            Person man4 = new Person(32, "Cooper");
            Person man5 = new Person(27, "Paul");

            ar.Add(man1);
            ar.Add(man2);
            ar.Add(man3);
            ar.Add(man4);
            ar.Add(man5);

            //
            foreach (var item in ar)
                Console.WriteLine(item);
            Console.WriteLine();

            //
            ar.Sort(new PersonCompareAsc());

            foreach (var item in ar)
                Console.WriteLine(item);
            Console.WriteLine();

            //
            ar.Sort(new PersonCompareDesc());

            foreach (var item in ar)
                Console.WriteLine(item);
            Console.WriteLine();

            //
            ar.Sort();

            foreach (var item in ar)
                Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}
