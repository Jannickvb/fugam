using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FugamUtil;
using FugamUtil.Identifier;
using FugamUtil.Packets.SubPackets;

namespace FugamServer
{
    public class ClientHandler
    {
        public FugamID FugamId { get; }
        private readonly GameHandler _game;
        public TcpClient Client { get; }
        private readonly Thread _clientThread;
        

        public ClientHandler(TcpClient client,int id,GameHandler game)
        {
            Client = client;
            _game = game;
            FugamId = new FugamID(Client.GetHashCode(),id);
            _clientThread = new Thread(new ThreadStart(ClientThread));
            ServerIO.Send(Client.GetStream(),new PacketFugamID(FugamId));
        }

        private void ClientThread()
        {
            while (Client.Connected)
            {
                //Console.WriteLine(FugamId + "\twaiting for packet\t" + DateTime.Now);
                ServerIO.Recieve(Client.GetStream()).HandleServerSide(_game);
                //Console.WriteLine(FugamId + "\tpacket received\t" + DateTime.Now);
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
