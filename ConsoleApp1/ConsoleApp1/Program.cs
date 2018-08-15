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
            Kilogram k1 = new Kilogram(5);
            Kilogram k2 = new Kilogram(10);

            Kilogram k3 = k1 + k2;
            Console.WriteLine(k3);
        }

    }

    class Kilogram
    {
        double mass;

        public Kilogram(double value)
        {
            this.mass = value;
        }

        public static Kilogram operator +(Kilogram k1, Kilogram k2)
        {
            return new Kilogram(k1.mass + k2.mass);
        }

        public override string ToString()
        {
            return this.mass.ToString() + " kg";
        }
    }

}
