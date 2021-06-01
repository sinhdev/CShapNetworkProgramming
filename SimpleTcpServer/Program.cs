using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SimpleTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Listen
            IPAddress address = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(address, 8888);
            Console.WriteLine("Sever is listening...");
            listener.Start();
            while(true){
                Socket socket = listener.AcceptSocket();
                //2. Receive
                byte[] data = new byte[1024];
                socket.Receive(data);
                string str = Encoding.UTF8.GetString(data);
                Console.WriteLine("Client name: \"" + str + "\"");
                //3. Send
                socket.Send(Encoding.UTF8.GetBytes("Hello, " + str));
                //4. Close
                socket.Close();
            }
            // Console.WriteLine("Server is closing...");
            // listener.Stop();
        }
    }
}
