using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using CommonType;

namespace MS
{
    class MS
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am Metadata Server!");

            TcpChannel channel = new TcpChannel(8087);
            ChannelServices.RegisterChannel(channel, true);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ClientToMS),
                "toMetadataServer",
                WellKnownObjectMode.Singleton);
                        
            Console.ReadLine();
        }
    }
}
