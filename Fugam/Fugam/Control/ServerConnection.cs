using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fugam.Control;
using Fugam.Model;
using FugamUtil;

namespace Fugam
{
    class ServerConnection
    {
        public TcpClient Client { get; }

        public ServerConnection()
        {
            Client = new TcpClient(Util.GetLocalIP().ToString(),Util.Port);
        }
    }
}
