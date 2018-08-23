using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DateTimeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            Console.WriteLine(now.Kind);

            now = DateTime.UtcNow;
            Console.WriteLine(now.Kind);
            Console.WriteLine();

            //
            DateTime before = DateTime.Now;
            long sum = Sum();
            DateTime after = DateTime.Now;
            Console.WriteLine("sum: " + sum);

            long gap = after.Ticks - before.Ticks;
            Console.WriteLine("Total ticks: " + gap);
            Console.WriteLine("Millisecond: " + (gap / 10000));
            Console.WriteLine("Second: " + (gap / 10000 / 1000));
            Console.WriteLine();

            //
            DateTime endOfYear = new DateTime(DateTime.Now.Year, 12, 31);
            now = DateTime.Now;
            TimeSpan gapDay = endOfYear - now;
            Console.WriteLine("올해의 남은 날: " + gapDay.TotalDays);
            Console.WriteLine();

            //
            Stopwatch st = new Stopwatch();
            st.Start();
            Sum();
            st.Stop();

            Console.WriteLine("Total ticks: " + st.ElapsedTicks);
            Console.WriteLine("Millisecond: " + st.ElapsedMilliseconds);
            Console.WriteLine("Second: " + st.Elapsed);
            Console.WriteLine();
        }

        static long Sum()
        {
            long sum = new long();

            for(int i = 0; i < 10000000; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}
