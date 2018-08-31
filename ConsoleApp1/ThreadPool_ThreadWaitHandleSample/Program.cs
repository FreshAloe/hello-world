using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace ThreadPool_ThreadWaitHandleSample
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
            number++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyData data = new MyData();

            Hashtable ht1 = new Hashtable();
            ht1["data"] = data;
            ht1["name"] = "thread1";
            ht1["evt"] = new EventWaitHandle(false, EventResetMode.ManualReset);
            ThreadPool.QueueUserWorkItem(ThreadFunc, ht1);
            
            Hashtable ht2 = new Hashtable();
            ht2["data"] = data;
            ht2["name"] = "thread2";
            ht2["evt"] = new EventWaitHandle(false, EventResetMode.ManualReset);
            ThreadPool.QueueUserWorkItem(ThreadFunc, ht2);

            (ht1["evt"] as EventWaitHandle).WaitOne();
            (ht2["evt"] as EventWaitHandle).WaitOne();

            Console.WriteLine(data.Number);
        }

        static void ThreadFunc(object obj)
        {
            Hashtable ht = obj as Hashtable;
            MyData data = ht["data"] as MyData;

            for (int i = 0; i < 100000; i++)
            {
                lock(data)
                {
                    Console.WriteLine(ht["name"]);
                    data.Increment();
                }
            }

            (ht["evt"] as EventWaitHandle).Set();
        }
    }
}
