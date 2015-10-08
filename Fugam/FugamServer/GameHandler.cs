using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FugamServer
{
    class GameHandler
    {
        private FugamServer _server;
        private Thread _gameThread;
        private ClientHandler[] _clients;

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
            while (ClientsConnected())
            {
                
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
    }
}
