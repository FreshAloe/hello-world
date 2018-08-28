using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace DataContactJsonSerializerSample
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int age;
        [DataMember]
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(Person));
            MemoryStream ms = new MemoryStream();
            Person man = new Person(36, "Anderson");

            dcjs.WriteObject(ms, man);
            ms.Position = 0;
            byte[] buf = ms.ToArray();
            Console.WriteLine(Encoding.UTF8.GetString(buf));

            ms.Position = 0;
            Person clone = dcjs.ReadObject(ms) as Person;
            Console.WriteLine(clone);
        }
    }
}
