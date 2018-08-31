using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSample4
{
    class MyData
    {
        int number = 0;
        public object _numberlock = new object();

        public int Number
        {
            get
            {
                return number;
            }
        }

        public void Increment()
        {
            lock(_numberlock)
            {
                number++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyData data = new MyData();

            Thread thread1 = new Thread(ThreadFunc);
            Thread thread2 = new Thread(ThreadFunc);
            thread1.Name = "thread1";
            thread2.Name = "thread2";
            thread1.Start(data);
            thread2.Start(data);

            thread1.Join();
            thread2.Join();

            Console.WriteLine(data.Number);
        }

        static void ThreadFunc(object obj)
        {
            MyData data = obj as MyData;

            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                lock (data)
                {
                    data.Increment();
                }
            }
        }
    }
}
