using System;

namespace UdpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPSocket s = new UDPSocket();
            s.Server("127.0.0.1", 33333);

            UDPSocket c = new UDPSocket();
            c.Client("127.0.0.1", 33333);
            c.Send("UDP TEST nguyễn xuân sinh!");
        }
    }
}
