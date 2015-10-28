using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FugamUtil;
using FugamUtil.Identifier;
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
            _clients = new ClientHandler[FugamServer.MaxPlayersEachGame];
        }

        public void AddPlayer(TcpClient client, int number)
        {
            _clients[number] = new ClientHandler(client,number,this);
        }

        public void StartGame()
        {
            Console.WriteLine("Game start: {0}", DateTime.Now);
            Console.WriteLine("Game Hashcode: {0}",GetHashCode());
            Game();
        }

        public void StopGame()
        {
            foreach (ClientHandler client in _clients)
            {
                client.Close();
            }
            Console.WriteLine("Game: {0} closed{1}",GetHashCode(),"");
        }


        //game logic
        private void Game()
        {
            foreach (ClientHandler client in _clients)
            {
                ServerIO.Send(client.Client.GetStream(),new PacketLevel(client.FugamId, "Level_ID1"));
                client.StartClientThread();
            }
            List<FugamID> playerids = _clients.Select(client => client.FugamId).ToList();

            foreach (ClientHandler client in _clients)
            {
                ServerIO.Send(client.Client.GetStream(), new PacketPlayers(client.FugamId,playerids));
            }
        }
        
        public void ReceivePacketPlayerPosition(PacketPlayerPosition ppp)
        {
            //Console.WriteLine("Packet received: "+ppp.FugamId.GameID);
            foreach (ClientHandler client in _clients)
            {
                if (!client.FugamId.Equals(ppp.FugamId))
                {
                    //Console.WriteLine("Send packet to: " + client.FugamId.GameID);
                    ServerIO.Send(client.Client.GetStream(), ppp);
                }
            }
        }
    }
}
