using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace SocketSample4
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
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 10200);
                socket.Bind(endPoint);
                socket.Listen(10);

                while (true)
                {
                    Socket clientSocket = socket.Accept();
                    ThreadPool.QueueUserWorkItem((WaitCallback)ClientSocketProcess, clientSocket);
                }
            }
        }

        static void ClientSocketProcess(object sck)
        {
            Socket clientSocket = sck as Socket;
            byte[] recvBytes = new byte[1024];

            int nRecv = clientSocket.Receive(recvBytes);
            string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

            Console.WriteLine("Server Recv - " + clientSocket.RemoteEndPoint + ": " + txt);

            byte[] sendBytes = Encoding.UTF8.GetBytes("hello: " + txt);
            clientSocket.Send(sendBytes);
            clientSocket.Close();
        }

        static void clientFunc(object obj)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 10200);

            clientSocket.Connect(serverEP);

            byte[] buf = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
            clientSocket.Send(buf);

            byte[] recvBytes = new byte[1024];
            int nRecv = clientSocket.Receive(recvBytes);
            string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

            Console.WriteLine("Client Recv - " + serverEP.ToString() + ": " + txt);
            Console.WriteLine();

            clientSocket.Close();
            Console.WriteLine("TCP Client socket: Closed");
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
