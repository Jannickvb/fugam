using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FugamUtil;
using FugamUtil.Interface;
using FugamUtil.Packets;
using FugamUtil.Packets.SubPackets;

namespace FugamServer
{
    class GameHandler : IServer
    {
        private FugamServer _server;
        private readonly ClientHandler[] _clients;

        public GameHandler(FugamServer server)
        {
            this._server = server;
            _clients = new ClientHandler[2];
        }

        public void AddPlayer(TcpClient client, int number)
        {
            _clients[number] = new ClientHandler(client,number,this);
        }

        public void StartGame()
        {
            Game();
        }

        public void StopGame()
        {
            foreach (ClientHandler client in _clients)
            {
                client.Close();
            }
        }


        //game logic
        private void Game()
        {
            foreach (ClientHandler client in _clients)
            {
                ServerIO.Send(client.Client.GetStream(),new Packet(client.GetHashCode()));
            }
            List<int> ids = _clients.Select(client => client.GetHashCode()).ToList();

            foreach (ClientHandler client in _clients)
            {
                ServerIO.Send(client.Client.GetStream(),new PacketPlayers(client.GetHashCode()) {IdPlayers = ids});
            }

            foreach (ClientHandler client in _clients)
            {
                ServerIO.Send(client.Client.GetStream(), new PacketLevel(client.GetHashCode(),"Level_ID1"));
                ServerIO.Recieve(client.Client.GetStream()).HandleServerSide(this);
            }

            foreach (ClientHandler client in _clients)
            {
                client.StartClientThread();
            }

            Console.WriteLine("Game: {0} closed{1}",GetHashCode(),"");
        }
        
        public void ResponsePacketLevel(PacketLevelRespone plr)
        {
            Console.WriteLine("Level is received: "+plr.Received);
        }

        public void ReceivePacketPlayerPosition(PacketPlayerPosition ppp)
        {
            foreach (ClientHandler client in _clients)
            {
                if (client.GetHashCode() != ppp.ClientId)
                {
                    ServerIO.Send(client.Client.GetStream(),ppp);
                }
            }
        }
    }
}
