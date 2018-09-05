using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Reflection;

namespace reflectionSample3
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom(@"C:\Users\capt1\Documents\GitHub\hello-world\ConsoleApp1\testDll\bin\Debug\testDll.dll");
            Type systemInfoType = asm.GetType("testDll.SystemInfo");

            //
            object objInstance = Activator.CreateInstance(systemInfoType);
            MethodInfo methodInfo = systemInfoType.GetMethod("WriteInfo", BindingFlags.NonPublic | BindingFlags.Instance); //private method
            methodInfo.Invoke(objInstance, null);
            Console.WriteLine();

            //
            ConstructorInfo ctorInfo = systemInfoType.GetConstructor(Type.EmptyTypes);
            object objInstance1 = ctorInfo.Invoke(null);

            MethodInfo methodInfo1 = systemInfoType.GetMethod("WriteInfo", BindingFlags.NonPublic | BindingFlags.Instance); //private method
            methodInfo1.Invoke(objInstance1, null);

            FieldInfo fieldInfo = systemInfoType.GetField("_is64Bit", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(objInstance1, !Environment.Is64BitOperatingSystem);

            methodInfo1.Invoke(objInstance1, null);

        }
    }
}
