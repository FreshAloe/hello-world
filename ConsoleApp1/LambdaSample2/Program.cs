using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaSample2
{
    class Program
    {
        delegate int? MyDevide(int a, int b);
        delegate int? MyAdd(int a, int b);

        static void Main(string[] args)
        {
            //MyDevide myDevide = delegate(int a, int b)
            //{
            //    if (b == 0)
            //    {
            //        return null;
            //    }

            //    return a / b;
            //}

            MyDevide myDevide = (a, b) =>
            {
                if (b == 0)
                {
                    return null;
                }

                return a / b;
            };

            Console.WriteLine("10 / 2 == " + myDevide(10, 2));
            Console.WriteLine("10 / 0 == " + myDevide(10, 0));
            Console.WriteLine();

            //
            //MyAdd myAdd = delegate (int a, int b)
            //{
            //    return a + b;
            //};

            MyAdd myAdd = (a, b) => a + b;

            Console.WriteLine("10 + 2 == " + myAdd(10, 2));
        }
    }
}
