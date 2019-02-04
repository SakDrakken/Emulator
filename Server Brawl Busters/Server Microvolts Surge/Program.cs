using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Server_Microvolts_Surge
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 13000;
            string IpAddress = "93.115.97.83";
            Socket ServerListener = new Socket(AddressFamily
                .InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IpAddress), port);
            ServerListener.Bind(ep);
            ServerListener.Listen(100);
            Console.WriteLine("Server is Listening...");
            Socket ClientSocket = default(Socket);
            int counter = 0;
            while (true)
            {
                counter++;
                ClientSocket = ServerListener.Accept();
                Console.WriteLine(counter + " Client Brawl Buster Connected");
                ThreadStart UserThread = (new ThreadStart(() => p.User(ClientSocket)));
            }
        }


        private class p
        {
            private static object client;
            private static object msg;

            internal static void User(Socket client)
            {
                while (true)
                {
                byte[] msg = new byte[1024];
                int size = client.Receive(msg);
                client.Send(msg, 0, size, SocketFlags.None);
                }


                throw new NotImplementedException();
            }
        }
    }
}
