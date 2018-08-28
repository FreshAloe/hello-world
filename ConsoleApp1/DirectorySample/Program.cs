using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectorySample
{
    class Program
    {
        static void Main(string[] args)
        {
            string targetPath = @"C:\Windows\Microsoft.NET";
            foreach(string txt in Directory.GetFiles(targetPath, "*.exe", SearchOption.AllDirectories))
            {
                Console.WriteLine(txt);
            }
        }
    }
}
