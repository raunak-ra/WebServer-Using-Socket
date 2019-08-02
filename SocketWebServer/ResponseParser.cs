using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketWebServer
{
    class ResponseParser
    {
        
        public byte[] ParseResponse(string FileName)
        {
            ContentType content = new ContentType();
            FileReader fileReader = new FileReader();

            
            byte[] payload = fileReader.ReadFile(FileName);
            int ContentLength = payload.Length;

            string contentType = content.GetType(FileName);

            // Building Response Header.
            string header = "HTTP /1.1 200 OK\nContent-Length: " + ContentLength + "\nContent-Type: " + contentType + "\n\n";
            byte[] headerByte = Encoding.ASCII.GetBytes(header);

            List<byte> responseByte = new List<byte>();
            responseByte.AddRange(headerByte);
            responseByte.AddRange(payload);

            return responseByte.ToArray();
    
         
        }
    }
}
