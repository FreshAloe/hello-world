using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSample1
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1} in {2}", Name, Age, Address);
        }
    }

    class MainLanguage
    {
        public string Name { get; set; }
        public string Language { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person() {Name = "Tom", Age = 63, Address = "Korea" },
                new Person() {Name = "Winnie", Age = 49, Address = "Tibet" },
                new Person() {Name = "Anders", Age = 47, Address = "Sudan" },
                new Person() {Name = "Hans", Age = 25, Address = "Tibet" },
                new Person() {Name = "Eureka", Age = 32, Address = "Sudan" },
                new Person() {Name = "Hawk", Age = 15, Address = "Korea" }
            };

            List<MainLanguage> languages = new List<MainLanguage>
            {
                new MainLanguage() {Name = "Anders", Language = "Delphi" },
                new MainLanguage() {Name = "Anders", Language = "C#" },
                new MainLanguage() {Name = "Tom", Language = "Borland C++" },
                new MainLanguage() {Name = "Hans", Language = "Visual C++" },
                new MainLanguage() {Name = "Winnie", Language = "R" }
            };

            //var all = from Person in people select Person;
            //IEnumerable<Person> all = from Person in people select Person;
            IEnumerable<Person> all = people.Select((item) => item) as IEnumerable<Person>;

            foreach (var item in all)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //
            all = SelectFunc(people);
            foreach (var item in all)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //
            //var nameList = from p in people select p.Name;
            IEnumerable<string> nameList = people.Select((p) => p.Name);

            foreach (var item in nameList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //
            nameList = SelectName(people);
            foreach (var item in nameList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //
            //var dataList = from p in people select new { Name = p.Name, Year = DateTime.Now.AddYears(-p.Age).Year };
            var dataList = people.Select((item) => new { Name = item.Name, Year = DateTime.Now.AddYears(-item.Age).Year });
            foreach (var item in dataList)
            {
                Console.WriteLine("{0} : {1}", item.Name, item.Year);
            }
            Console.WriteLine();

            //where
            var ageOver30 = from p in people where p.Age > 30 select p;
            foreach (var item in ageOver30)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //where
            var endWithS = from p in people where p.Name.EndsWith("s") select p;
            foreach (var item in endWithS)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //orderby
            var ageSortAsc = from p in people orderby p.Age ascending select p;
            foreach (var item in ageSortAsc)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            //orderby
            var ageSortDesc = from p in people orderby p.Age descending select p;
            foreach (var item in ageSortDesc)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //group by
            var addrGroup = from p in people orderby p.Age group p by p.Address;
            foreach (var itemGroup in addrGroup)
            {
                Console.WriteLine("[{0}]", itemGroup.Key);

                foreach(var item in itemGroup)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();    
            }
        }

        static IEnumerable<Person> SelectFunc(List<Person> people)
        {
            foreach(Person item in people)
            {
                yield return item;
            }
        }

        static IEnumerable<string> SelectName(List<Person> people)
        {
            foreach(Person item in people)
            {
                yield return item.Name;
            }
        }
    }
}
