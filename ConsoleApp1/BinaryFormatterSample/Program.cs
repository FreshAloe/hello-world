using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BinaryFormatterSample
{
    [Serializable]
    class Person
    {
        int age;
        string name;

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
            Person man1 = new Person(36, "Anderson");
            Person man2 = new Person(49, "FreshAloe");

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            bf.Serialize(ms, man1);
            bf.Serialize(ms, man2);

            ms.Position = 0;
            byte[] buf = ms.ToArray();
            Console.WriteLine(BitConverter.ToString(buf));
            Console.WriteLine();

            ms.Position = 0;
            Person clone1 = bf.Deserialize(ms) as Person;
            Person clone2 = bf.Deserialize(ms) as Person;

            Console.WriteLine(clone1);
            Console.WriteLine(clone2);
        }
    }
}
