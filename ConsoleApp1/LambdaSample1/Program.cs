using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LambdaSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(
            //    delegate (object obj)
            //    {
            //        Console.WriteLine("ThreadFunc in anonymous method called!");
            //    });

            Thread thread = new Thread(
                (object obj) =>
                {
                    Console.WriteLine("ThreadFunc in anonymous method called!");
                });

            thread.Start();
            thread.Join();
        }
    }
}
