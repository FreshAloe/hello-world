using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSample3
{
    class Program
    {
        int number = 0;

        static void Main(string[] args)
        {
            Program pg = new Program();

            Thread thread1 = new Thread(ThreadFunc);
            Thread thread2 = new Thread(ThreadFunc);

            thread1.Start(pg);
            thread2.Start(pg);

            thread1.Join();
            thread2.Join();

            Console.WriteLine(pg.number);
        }

        static void ThreadFunc(object obj)
        {
            Program pg = obj as Program;

            for (int i = 0; i < 10000; i++)
            {
                /*
                Monitor.Enter(pg);
                try
                {
                    pg.number++;
                }
                finally
                {
                    Monitor.Exit(pg);
                }*/

                lock (pg)
                {
                    pg.number++;
                }
            }
        }
    }
}
