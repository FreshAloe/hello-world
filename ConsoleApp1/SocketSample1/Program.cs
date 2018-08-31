using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace SocketSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            Thread serverThread = new Thread(ServerFunc);
            serverThread.IsBackground = true;
            serverThread.Start();
            Thread.Sleep(500);

            //
            for (int i = 0; i < 3; i++)
            {
                Thread clientThread = new Thread(clientFunc);
                clientThread.IsBackground = true;
                clientThread.Start();
            }

            Console.WriteLine("종료하려면 아무 키나 누르세요.");
            Console.ReadLine();
        }

        static void ServerFunc(object obj)
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                /*
                IPAddress ipAddress = GetCurrentAddress();

                if (ipAddress == null)
                {
                    Console.WriteLine("IPv4용 랜카드가 없습니다.");
                    return;
                }

                IPEndPoint endPoint = new IPEndPoint(ipAddress, 10200);
                socket.Bind(endPoint);
                */

                /*
                IPAddress ipAddress = IPAddress.Parse("0.0.0.0");
                IPEndPoint endPoint = new IPEndPoint(ipAddress, 10200);
                socket.Bind(endPoint);
                */

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 10200);
                socket.Bind(endPoint);

                byte[] recvBytes = new byte[1024];
                EndPoint clientEp = new IPEndPoint(IPAddress.None, 0);

                while(true)
                {
                    int nRecv = socket.ReceiveFrom(recvBytes, ref clientEp);
                    string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

                    Console.WriteLine("Server Recv - " + clientEp.ToString() + ": " + txt);

                    byte[] sendBytes = Encoding.UTF8.GetBytes("hello: " + txt);
                    socket.SendTo(sendBytes, clientEp);
                }
            }

        }

        static void clientFunc(object obj)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 10200);
            EndPoint senderEP = new IPEndPoint(IPAddress.None, 0);

            int nTimes = 5;

            while(nTimes-- > 0)
            {
                byte[] buf = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
                clientSocket.SendTo(buf, serverEP);

                byte[] recvBytes = new byte[1024];
                int nRecv = clientSocket.ReceiveFrom(recvBytes, ref senderEP);
                string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

                Console.WriteLine("Client Recv - " + senderEP.ToString() + ": " + txt);
                Console.WriteLine();
                Thread.Sleep(1000);
            }

            clientSocket.Close();
            Console.WriteLine("UDP Client socket: Closed");
        }

        static IPAddress GetCurrentAddress()
        {
            IPAddress[] addrs = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

            foreach (IPAddress ipAddr in addrs)
            {
                if (ipAddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddr;
                }
            }

            return null;
        }
    }
}
