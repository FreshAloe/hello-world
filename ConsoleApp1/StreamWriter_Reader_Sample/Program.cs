using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Stream에 문자열 데이터를 쓰려면 반드시 그전에 Encoding 타입을 이용하여 byte 배열로 변환한 후 작업해야 한다.
//이런 불편함을 해소하기 위하여 문자열 데이터를 Stream에 쉽게 쓸수 있는 용도로 StreamWriter 타입을 지원한다.
namespace StreamWriter_Reader_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryStream ms = new MemoryStream();

            StreamWriter sw = new StreamWriter(ms, Encoding.UTF8);
            sw.WriteLine("Hello World!");
            sw.WriteLine("Anderson");
            sw.WriteLine(32000); //문자열이 아니어도 ToString()으로 반환된 값을 쓴다.
            sw.Flush();

            //
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms, Encoding.UTF8);
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine();

            ms.Position = 0;
            string txt = sr.ReadToEnd();
            Console.WriteLine(txt);
            Console.WriteLine();
        }
    }
}
