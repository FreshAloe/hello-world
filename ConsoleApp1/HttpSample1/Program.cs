using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace HttpSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress[] ips = Dns.GetHostEntry("www.naver.com").AddressList;
            foreach (IPAddress item in ips)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            EndPoint serverEP = new IPEndPoint(ips[0], 80);

            socket.Connect(serverEP);

            //
            string request = "GET / HTTP/1.0\r\nHOST: www.naver.com\r\n\r\n";
            byte[] sendBuf = Encoding.UTF8.GetBytes(request);
            socket.Send(sendBuf);

            MemoryStream ms = new MemoryStream();
            while(true)
            {
                byte[] rcvBuf = new byte[4096];
                int nRecv = socket.Receive(rcvBuf);

                if (nRecv == 0)
                {
                    break;
                }

                ms.Write(rcvBuf, 0, nRecv);
            }

            socket.Close();

            string response = Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);
            Console.WriteLine(response);

            File.WriteAllText("daum.html", response);
        }
    }
}
