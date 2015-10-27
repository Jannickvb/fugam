using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using FugamUtil.Packets;

namespace FugamUtil
{
    public class ServerIO
    {
        private readonly static BinaryFormatter Formatter = new BinaryFormatter();

        public static void Send(Stream stream, Packet packet)
        {
            Formatter.Serialize(stream,packet);
        }

        public static Packet Recieve(Stream stream)
        {
            return (Packet)Formatter.Deserialize(stream);
        }
    }
}
