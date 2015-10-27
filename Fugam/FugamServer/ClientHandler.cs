using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FugamUtil;

namespace FugamServer
{
    class ClientHandler
    {
        public int Id { get; }
        private GameHandler _game;
        public TcpClient Client { get; }
        private Thread _clientThread;
        

        public ClientHandler(TcpClient client,int id,GameHandler game)
        {
            Client = client;
            _game = game;
            id++;
            Id = id;
            _clientThread = new Thread(new ThreadStart(ClientThread));
        }

        private void ClientThread()
        {
            while (Client.Connected)
            {
                ServerIO.Recieve(Client.GetStream()).HandleServerSide(_game);
            }
        }

        public void StartClientThread()
        {
            _clientThread.Start();
        }

        public void Close()
        {
            _clientThread.Abort();
            Client.Close();
        }
        
    }
}
