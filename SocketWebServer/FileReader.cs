using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketWebServer
{
    public class FileReader
    {
        static readonly string DirectoryPath = @"C:\Users\rsingh\source\repos\SocketWebServer\ServerContent";
        public byte[] ReadFile(string FileName)
        {
            byte[] FileData;

            if (File.Exists(DirectoryPath + FileName))
            {
                //Console.WriteLine(File.ReadAllText(DirectoryPath + FileName));
                FileData = File.ReadAllBytes(DirectoryPath + FileName);
            }
            else
            {    
                FileData = Encoding.ASCII.GetBytes("<html><body><h1>File Not Found!!</h1></body></html>");
            }

            return FileData;

        }
    }
}
