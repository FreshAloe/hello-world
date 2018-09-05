using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Remoting;

namespace ReflectionSample2
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain newAppDomain = AppDomain.CreateDomain("MyAppDomain");
            string dllPath = @"C:\Users\capt1\Documents\GitHub\hello-world\ConsoleApp1\testDll\bin\Debug\testDll.dll";
            ObjectHandle objHandle = newAppDomain.CreateInstanceFrom(dllPath, "testDll.Class1");
            AppDomain.Unload(newAppDomain);

            //
            Assembly asm = Assembly.LoadFile(dllPath);
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.Load(asm.FullName);
        }
    }
}
