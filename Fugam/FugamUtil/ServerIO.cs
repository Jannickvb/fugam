using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FugamUtil
{
    public class ServerIO
    {
        private readonly static BinaryFormatter Formatter = new BinaryFormatter();

        public static void Send(Stream stream, object ob)
        {
            Formatter.Serialize(stream,ob);
        }

        public static object Recieve(Stream stream)
        {
            return Formatter.Deserialize(stream);
        }
    }
}
