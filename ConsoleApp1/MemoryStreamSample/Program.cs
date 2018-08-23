using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//MemoryStream - Stream 추상 클래스를 상속받음. 메모리에 바이트 데이터를 순서대로 읽고 쓰는 작업을 수행하는 클래스.
//이를 이용하여 데이터를 메모리에 직렬화/역직렬화 한다.
namespace MemoryStreamSample
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] shortBytes = BitConverter.GetBytes((short)32000);
            byte[] intBytes = BitConverter.GetBytes(1652300);

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(shortBytes, 0, shortBytes.Length);
                ms.Write(intBytes, 0, intBytes.Length);

                ms.Position = 0;

                byte[] result = new byte[2];
                ms.Read(result, 0, 2);
                short shortResult = BitConverter.ToInt16(result, 0);
                Console.WriteLine(shortResult);

                result = new byte[4];
                ms.Read(result, 0, 4);
                int intResult = BitConverter.ToInt32(result, 0);
                Console.WriteLine(intResult);
                Console.WriteLine();

                //
                ms.Position = 0;
                byte[] buf = ms.ToArray();
                Console.WriteLine(BitConverter.ToString(buf));
                shortResult = BitConverter.ToInt16(buf, 0);
                intResult = BitConverter.ToInt32(buf, 2);
                Console.WriteLine(shortResult);
                Console.WriteLine(intResult);
                Console.WriteLine();
            }

            using (MemoryStream ms = new MemoryStream())
            {
                byte[] buf = Encoding.UTF8.GetBytes("Hello World!");

                ms.Write(buf, 0, buf.Length);

                ms.Position = 0;
                byte[] readBuf = new byte[buf.Length];
                ms.Read(readBuf, 0, buf.Length);

                string txt = Encoding.UTF8.GetString(readBuf);
                Console.WriteLine(txt);
            }
        }
    }
}
