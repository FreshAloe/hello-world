using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello World";
            Console.WriteLine(text.GetWordCount());
        }
    }

    static class ExtensionMethod
    {
        public static int GetWordCount(this string txt)
        {
            return txt.Split(' ').Length;
        }
    }
}
