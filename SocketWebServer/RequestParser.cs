using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketWebServer
{
    class RequestParser
    {
        static int count = 0;
        public string ParseRequest(Socket handler)
        {
            Console.WriteLine("Parsing.....");

            string data = String.Empty;
            byte[] bytes = new byte[1024];


            int bytesRec = handler.Receive(bytes);
            data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            Console.WriteLine(data);

            string[] str = data.Split(' ');
            Console.WriteLine(".......................................");
            Console.WriteLine("Requested..."+ (count++));
            Console.WriteLine(".......................................");

            Console.WriteLine(data);
            

            if(str[1]=="/favicon.ico" || !(str[1].Contains('.')))
            {
                return "/notfound.jpg";
            }
            
            return str[1];
        }

        
    }
}
