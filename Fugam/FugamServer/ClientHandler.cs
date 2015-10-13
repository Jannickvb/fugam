using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FugamServer
{
    class ClientHandler
    {
        private readonly TcpClient _client;
        private readonly BinaryFormatter _formatter;

        public int Id { get; }
        public TcpClient Client => _client;

        public ClientHandler(TcpClient client,int id)
        {
            this._client = client;
            id++;
            this.Id = id;
            _formatter = new BinaryFormatter();
        }

        public void Close()
        {
            _client.Close();
        }

        public void WriteTextMessage(string message)
        {
            _formatter.Serialize(_client.GetStream(),message);
        }

        public string ReadTextMessage()
        {
            return (string)_formatter.Deserialize(_client.GetStream());
        }
    }
}
