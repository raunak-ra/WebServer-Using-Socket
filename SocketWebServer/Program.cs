using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServer webServer = new WebServer();
            webServer.Start();
        }
    }
}
