using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaSample3
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> logout = (txt) =>
            {
                Console.WriteLine(DateTime.Now + ": " + txt);
            };

            logout("This is my world!");

            //
            Func<double> pi = () => 3.141592;
            Console.WriteLine(pi());

            //
            Func<int, int, int> myAdd = (a, b) => a + b;
            Console.WriteLine("10 + 2 == " + myAdd(10, 2));
        }
    }
}
