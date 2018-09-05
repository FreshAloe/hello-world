using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDll
{
    public class Class1
    {
        public Class1()
        {
            Console.WriteLine(typeof(Class1).FullName + ": Created");
        }

        public void AccessTest()
        {
            Console.WriteLine("AccessTest!");
        }
    }

    class SystemInfo
    {
        bool _is64Bit;

        public SystemInfo()
        {
            _is64Bit = Environment.Is64BitOperatingSystem;
            Console.WriteLine("SystemInfo Created!");
        }

        private void WriteInfo()
        {
            Console.WriteLine("OS == {0}bits", (_is64Bit == true) ? "64" : "32");
        }
    }
}
