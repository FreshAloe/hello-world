using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileStreamSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            Console.WriteLine();

            //
            FileStream fs = new FileStream("test.log", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Hello World");
            sw.WriteLine("Anderson");
            sw.WriteLine(32000);
            sw.Flush();
            sw.Dispose();
            fs.Close();
            fs.Dispose();

            FileStream fsr = new FileStream("test.log", FileMode.Open);
            StreamReader sr = new StreamReader(fsr);
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            sr.Dispose();
            fsr.Close();
            fsr.Dispose();

            Console.WriteLine();

            //
            FileStream fs1 = new FileStream("test1.log", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs1);

            bw.Write("Hello World" /*+ Environment.NewLine*/);
            bw.Write("Anderson" /*+ Environment.NewLine*/);
            bw.Write(32000);
            //bw.Write(Environment.NewLine);
            bw.Flush();
            bw.Dispose();
            fs1.Close();
            fs1.Dispose();

            FileStream fsr1 = new FileStream("test1.log", FileMode.Open);
            BinaryReader br = new BinaryReader(fsr1);
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadInt32());
            br.Dispose();
            fsr1.Close();
            fsr1.Dispose();
        }
    }
}
