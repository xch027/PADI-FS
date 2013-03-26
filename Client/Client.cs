using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Net.Sockets;
using CommonType;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am Client!");
            string semantic = "default";
            TcpChannel channel = new TcpChannel();            
            ChannelServices.RegisterChannel(channel, true);            
            ClientToDS objDS = (ClientToDS)Activator.GetObject(
                typeof(ClientToDS),
                "tcp://localhost:8086/toDataServer");
            ClientToMS objMS = (ClientToMS)Activator.GetObject(
                typeof(ClientToMS),
                "tcp://localhost:8087/toMetadataServer");
            
            string fileName = @"data.txt";
            string fileContent = "here is D1\r\nthis is 1st data server";
            
            try
            {
                Console.WriteLine(objDS.writeFile(fileName,fileContent));
                Console.WriteLine("The file content in Data Server is:");
                Console.WriteLine(objDS.readFile(fileName,semantic));

                objMS.CreateMetadataFile("data.txt",4,2,3);
                Console.WriteLine("The file content in Metadata Server is:");
                Console.WriteLine(objMS.OpenMetadataFile("data.txt"));
                objMS.deleteMetadataFile("data.txt");
                Console.WriteLine("The file content in Metadata Server is:");
                Console.WriteLine(objMS.OpenMetadataFile("data.txt"));
            }
            catch (SocketException)
            {
                System.Console.WriteLine("Could not locate server");
            }

            Console.ReadLine();
        }
    }
}
