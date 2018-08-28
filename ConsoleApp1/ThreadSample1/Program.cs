using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSample1
{
    class ThreadParam
    {
        public int value1;
        public int value2;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(ThreadFunc);
            ThreadParam p = new ThreadParam();
            p.value1 = 10;
            p.value2 = 20;

            t.Start(p);
        }

        static void ThreadFunc(object initialValue)
        {
            ThreadParam p = initialValue as ThreadParam;
            Console.WriteLine("{0}, {1}", p.value1, p.value2);
        }
    }
}
