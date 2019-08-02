using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketWebServer
{
    internal class WebServer
    {
        public void Start()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8000);
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);

            Console.WriteLine("Waiting for a connection...");
            listener.Listen(10);

            while (true)
            {
                Socket handler = listener.Accept();
                Thread runThread = new Thread(() => Run(handler));
                runThread.Start();
            }
       
            
            Console.ReadKey(true);
        }

        public void Run(Socket handler)
        {
          
            RequestParser request = new RequestParser();
            string fileName = request.ParseRequest(handler);

            ResponseParser responseParser = new ResponseParser();
            byte[] msg = responseParser.ParseResponse(fileName);

            Console.WriteLine(msg);

            handler.Send(msg);
            Console.WriteLine();
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}