using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("Current Domain Name: " + currentDomain);
            foreach (Assembly asm in currentDomain.GetAssemblies())
            {
                Console.WriteLine("\t" + asm.FullName);

                foreach(Module module in asm.GetModules())
                {
                    Console.WriteLine("\t\t" + module.FullyQualifiedName);

                    foreach(Type type in module.GetTypes())
                    {
                        Console.WriteLine("\t\t\t" + type.FullName);

                        foreach(MemberInfo memberInfo in type.GetMembers())
                        {
                            Console.WriteLine("\t\t\t\t" + memberInfo.Name);
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
