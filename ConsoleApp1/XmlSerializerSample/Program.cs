using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace XmlSerializerSample
{
    public class Person
    {
        public int age;
        public string name;

        public Person() { }

        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public override string ToString()
        {
            return string.Format("{0, 5} {1, -10}", age, name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MemoryStream ms = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(Person));

            Person man1 = new Person(36, "Anderson");
            Person man2 = new Person(49, "FreshAloe");

            xs.Serialize(ms, man1);
            xs.Serialize(ms, man2);
            ms.Position = 0;
            byte[] buf = ms.ToArray();
            Console.WriteLine(Encoding.UTF8.GetString(buf));
            Console.WriteLine();

            ms.Position = 0;
            Person clone1 = xs.Deserialize(ms) as Person;
            Person clone2 = xs.Deserialize(ms) as Person;

            Console.WriteLine(clone1);
            Console.WriteLine(clone2);
        }
    }
}
