using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitConverterSample
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] boolBytes = BitConverter.GetBytes(true);
            byte[] shortBytes = BitConverter.GetBytes((short)32000);
            byte[] intBytes = BitConverter.GetBytes(1652300);

            Console.WriteLine(BitConverter.ToString(boolBytes));
            Console.WriteLine(BitConverter.ToString(shortBytes));
            Console.WriteLine(BitConverter.ToString(intBytes));
            Console.WriteLine();

            bool boolResult = BitConverter.ToBoolean(boolBytes, 0);
            short shortResult = BitConverter.ToInt16(shortBytes, 0);
            int intResult = BitConverter.ToInt32(intBytes, 0);

            Console.WriteLine(boolResult);
            Console.WriteLine(shortResult);
            Console.WriteLine(intResult);
            Console.WriteLine();

            //
            byte[] totBytes = new byte[boolBytes.Length + shortBytes.Length + intBytes.Length];
            Array.Copy(boolBytes, totBytes, boolBytes.Length);
            Array.Copy(shortBytes, 0, totBytes, boolBytes.Length, shortBytes.Length);
            Array.Copy(intBytes, 0, totBytes, boolBytes.Length + shortBytes.Length, intBytes.Length);

            Console.WriteLine(BitConverter.ToString(totBytes));

            boolResult = BitConverter.ToBoolean(totBytes, 0);
            shortResult = BitConverter.ToInt16(totBytes, boolBytes.Length);
            intResult = BitConverter.ToInt32(totBytes, boolBytes.Length + shortBytes.Length);

            Console.WriteLine(boolResult);
            Console.WriteLine(shortResult);
            Console.WriteLine(intResult);
            Console.WriteLine();

            //
            byte[] buf = new byte[4];
            buf[0] = 0x4C;
            buf[1] = 0x36;
            buf[2] = 0x19;
            buf[3] = 0x00;
            int result = BitConverter.ToInt32(buf, 0);
            Console.WriteLine(BitConverter.ToString(buf) + " : " + result);
            Console.WriteLine();

            //
            int n = 1652300;
            string text = n.ToString();
            int r = int.Parse(text);
            Console.WriteLine(r);
        }
    }
}
