using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerSample2
{
    class Notebook
    {
        int inch;
        int ram;

        public Notebook(int inch, int ram)
        {
            this.inch = inch;
            this.ram = ram;
        }

        public int this[string propertyName]
        {
            get
            {
                switch(propertyName)
                {
                    case "inch":
                        return inch;

                    case "ram":
                        return ram;
                }

                return -1;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Notebook notebook = new Notebook(13, 4);

            Console.WriteLine("Monitor: " + notebook["inch"]);
            Console.WriteLine("Ram: " + notebook["ram"]);
        }
    }
}
