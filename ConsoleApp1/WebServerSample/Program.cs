using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WebServerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                Console.WriteLine("http://localhost:8000 으로 방문해보세요.");
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 8000);
                socket.Bind(endPoint);
                socket.Listen(10);

                while(true)
                {
                    Socket clientSocket = socket.Accept();
                    ThreadPool.QueueUserWorkItem(httpServerFunc, clientSocket);
                }
            }
        }

        static void httpServerFunc(object state)
        {
            Socket s = state as Socket;

            string sndMsg = File.ReadAllText("naver.html");
            Console.WriteLine(sndMsg);

            byte[] reqBuf = new byte[4096];
            s.Receive(reqBuf);
            Console.WriteLine(Encoding.UTF8.GetString(reqBuf));
            Console.WriteLine();
            
            byte[] resBuf = Encoding.UTF8.GetBytes(sndMsg);
            s.Send(resBuf);

            s.Close();
        }
    }
}
