using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace YieldSample2
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(int n in YieldNaturalNumber.next(1000))
            {
                Console.WriteLine(n);
            }
        }

        class YieldNaturalNumber
        {
            public static IEnumerable<int> next(int max)
            {
                int _start = 0;
                while(true)
                {
                    _start++;

                    if (max < _start)
                    {
                        yield break;
                    }

                    yield return _start;
                }
            }
        }
    }
}
