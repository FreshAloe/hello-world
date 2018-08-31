using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DnsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string mycomputer = Dns.GetHostName();
            Console.WriteLine("컴퓨터 이름: " + mycomputer);

            IPHostEntry entry = Dns.GetHostEntry(mycomputer);
            foreach (IPAddress ipAddress in entry.AddressList)
            {
                Console.WriteLine(ipAddress.AddressFamily + " : " + ipAddress);
            }

            //
            Console.WriteLine();

            string naver = "www.Naver.com";
            entry = Dns.GetHostEntry(naver);
            foreach (IPAddress ip in entry.AddressList)
            {
                Console.WriteLine(ip.AddressFamily + " : " + ip);
            }
        }
    }
}
