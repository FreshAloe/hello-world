using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventSample1
{
    //class CallbackArg { }

    //class PrimeCallbackArg : CallbackArg
    class PrimeCallbackArg : EventArgs
    {
        public int Prime;

        public PrimeCallbackArg(int prime)
        {
            this.Prime = prime;
        }
    }

    class PrimeGenerator
    {
        //public delegate void PrimeDelegate(object sender, CallbackArg arg);
        //public PrimeDelegate callbacks;
        public event EventHandler PrimeGenerated;

        //public void AddDelegate(PrimeDelegate callback)
        //{
        //    callbacks += callback;
        //}

        //public void RemoveDelegate(PrimeDelegate callback)
        //{
        //    callbacks -= callback;
        //}

        public void Run(int limit)
        {
            for (int i = 2; i <= limit; i++)
            {
                //if (IsPrime(i) == true && callbacks != null)
                //{
                //    callbacks(this, new PrimeCallbackArg(i));
                //}

                if (IsPrime(i) == true && PrimeGenerated != null)
                {
                    PrimeGenerated(this, new PrimeCallbackArg(i));
                }
            }
        }

        bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
                return candidate == 2;

            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                    return false;
            }

            return candidate != 1;
        }
    }

    class Program
    {
        static void PrintPrime(object sender, EventArgs arg)
        {
            Console.Write
                ((arg as PrimeCallbackArg).Prime + ", ");
        }

        static int sum;

        static void SumPrime(object sender, EventArgs arg)
        {
            sum += (arg as PrimeCallbackArg).Prime;
        }

        static void Main(string[] args)
        {
            PrimeGenerator gen = new PrimeGenerator();

            //PrimeGenerator.PrimeDelegate callPrint = PrintPrime;
            //gen.AddDelegate(PrintPrime);

            //PrimeGenerator.PrimeDelegate callSum = SumPrime;
            //gen.AddDelegate(callSum);

            gen.PrimeGenerated += PrintPrime;
            gen.PrimeGenerated += SumPrime;

            gen.Run(10);
            Console.WriteLine();
            Console.WriteLine(sum);

            //gen.RemoveDelegate(callSum);
            gen.PrimeGenerated -= SumPrime;
            gen.Run(15);
            Console.WriteLine();
        }
    }
}
