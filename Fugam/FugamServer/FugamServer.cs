using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FugamUtil;

namespace FugamServer
{
    class FugamServer
    {
        static void Main(string[] args)
        {
            new FugamServer(Util.GetLocalIP(), Util.Port);
        }

        private TcpListener _server;
        private IPAddress _ip;
        private int _port;

        public FugamServer(IPAddress ip, int port)
        {
            this._ip = ip;
            this._port = port;

            _server = new TcpListener(_ip,_port);
            ServerStart();
        }

        private void ServerStart()
        {
            _server.Start();
            Console.WriteLine("Server start: {0}", DateTime.Now);
            Console.WriteLine("Server Hashcode: {0}", this.GetHashCode());

            bool running = true;

            int currentClients = 0;
            GameHandler game = new GameHandler(this);
            Console.WriteLine("Game start: {0}", DateTime.Now);
            Console.WriteLine("Game Hashcode: {0}", game.GetHashCode());

            while (running)
            {
                TcpClient client = _server.AcceptTcpClient();
                Console.WriteLine("Client connected: {0}Added to {1} game{2}",client.GetHashCode(),"\n"+game.GetHashCode(),"");

                game.AddPlayer(client,currentClients);
                currentClients++;

                if (currentClients == 2)
                {
                    game.StartGame();
                    currentClients = 0;
                    game = new GameHandler(this);
                    Console.WriteLine("Game start: {0}", DateTime.Now);
                    Console.WriteLine("Game Hashcode: {0}", game.GetHashCode());
                }
            }
        }

    }
}
