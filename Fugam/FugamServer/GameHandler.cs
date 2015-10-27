using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FugamUtil;
using FugamUtil.Interface;
using FugamUtil.Packets.SubPackets;

namespace FugamServer
{
    class GameHandler : IServer
    {
        private FugamServer _server;
        private Thread _gameThread;
        private readonly ClientHandler[] _clients;

        public GameHandler(FugamServer server)
        {
            this._server = server;
            _clients = new ClientHandler[2];
        }

        public void AddPlayer(TcpClient client, int number)
        {
            _clients[number] = new ClientHandler(client,number);
        }

        public void StartGame()
        {
            _gameThread = new Thread(new ThreadStart(Game));
            _gameThread.Start();
        }

        public void StopGame()
        {
            _gameThread.Abort();
        }


        //game logic
        private void Game()
        {
            foreach (ClientHandler client in _clients)
            {
                ServerIO.Send(client.Client.GetStream(), new PacketLevel("Level_ID1"));
                ServerIO.Recieve(client.Client.GetStream()).HandleServerSide(this);
            }

            while (ClientsConnected())
            {
                foreach (ClientHandler client in _clients)
                {
                    
                }
            }

            Console.WriteLine("Game: {0} closed{1}",GetHashCode(),"");
        }
        
        private bool ClientsConnected()
        {
            foreach (ClientHandler client in _clients)
            {
                if (!client.Client.Connected)
                {
                    return false;
                }
            }
            return true;
        }

        public void ResponsePacketLevel(PacketLevelRespone plr)
        {
            Console.WriteLine(plr.Received);
        }
    }
}
