using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enumSample
{
    class Program
    {
        [Flags] public enum Days
        {
            Sunday = 1, Monday = 2, Tuesday = 4, Wednessday = 8, Thursday = 16, Friday = 32, Saturday = 64
        }

        static void Main(string[] args)
        {
            Days workingDays = Days.Monday | Days.Tuesday | Days.Wednessday | Days.Thursday | Days.Friday;

            Console.WriteLine(workingDays.HasFlag(Days.Sunday));

            Days today = Days.Friday;
            Console.WriteLine(workingDays.HasFlag(today));

            Console.WriteLine(workingDays);
        }
    }
}
