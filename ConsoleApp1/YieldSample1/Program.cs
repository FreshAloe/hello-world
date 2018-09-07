using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace YieldSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            NaturalNumber num = new NaturalNumber();
            foreach(int n in num)
            {
                Console.WriteLine(n);
            }
            */

            foreach (int n in YieldNaturalNumber.Next())
            {
                Console.WriteLine(n);
            }
        }
    }

    class NaturalNumber : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new NaturalNumberEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NaturalNumberEnumerator();
        }
    }

    class NaturalNumberEnumerator : IEnumerator<int>
    {
        int _current;

        public int Current()
        {
            return _current;
        }

        object IEnumerator.Current
        {
            get
            {
                return _current;
            }
        }

        int IEnumerator<int>.Current
        {
            get
            {
                return _current;
            }
        }

        public bool MoveNext()
        {
            _current++;
            return true;
        }

        public void Reset()
        {
            _current = 0;
        }

        public void Dispose() { }
    }

    class YieldNaturalNumber
    {
        public static IEnumerable<int> Next()
        {
            int _start = 0;
            while(true)
            {
                _start++;
                yield return _start;
            }
        }
    }
}
