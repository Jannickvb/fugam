using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FugamServer
{
    class ClientHandler
    {
        private TcpClient _client;
        public int Id { get; }

        public TcpClient Client => _client;

        public ClientHandler(TcpClient client,int id)
        {
            this._client = client;
            id++;
            this.Id = id;
        }
    }
}
