using System;
using System.Net;
using System.Net.NetworkInformation;

namespace NetDemo
{
    class Program
    {
        static bool CheckInternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            if (CheckInternetConnection())
            {
                Console.WriteLine("Connected to the internet!");
                using (var client = new WebClient())
                {
                    //get external ip address
                    string externalIpString = client.DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
                    var externalIp = IPAddress.Parse(externalIpString);
                    Console.WriteLine("External Your IP: {0}", externalIp);
                    Console.ReadLine();

                    //download file
                    client.DownloadFile("https://sinhnx.dev/uploads/3801c960-825b-48df-9a29-f8b942aa8afb/dotNET_1140x450.png", "dotNET.png");

                    //download html code & show html code
                    string htmlCode = client.DownloadString("https://sinhnx.dev/");
                    Console.WriteLine(htmlCode);
                }
            }
            else
            {
                Console.WriteLine("Not connected to the internet!");
            }
        }
    }
}
