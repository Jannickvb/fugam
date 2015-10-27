using Fugam.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fugam.View;
using FugamUtil;

namespace Fugam.Control
{
    public class GameStateManager
    {
        public int PANEL_WIDTH { get; }
        public int PANEL_HEIGHT { get; }

        private readonly List<GameState> _gameStateList;
        public GameState CurrentState { get; set; }

        public Font GAME_FONT { get; }
        public Brush GAME_STRING_BRUSH { get; }

        private GEngine _gEngine;
        public TcpClient Client { get; set; }

        public int ServerClientID { get; set; }

        private readonly Thread _updateThread;

        public GameStateManager(int width, int height)
        {
            PANEL_WIDTH = width;
            PANEL_HEIGHT = height;
            GAME_FONT = new Font("Arial",16);
            

            _gameStateList = new List<GameState>();
            _gameStateList.Add(new BeginState(this));
            _gameStateList.Add(new Level1(this));

            SetState(State.Begin);

            _updateThread = new Thread(new ThreadStart(Update));
        }

        public void StartGame(Graphics g)
        {
            _gEngine = new GEngine(this,g);
            _gEngine.Init();

            
            _updateThread.Start();
        }

        public void StopGame()
        {
            _gEngine.Stop();
            _updateThread.Abort();
        }

        public void SetState(State s)
        {
            CurrentState = _gameStateList.ElementAt((int) s);
            CurrentState.init();
        }

        public void ConnectServer()
        {
            Client = new TcpClient(Util.GetLocalIP().ToString(), Util.Port);
        }

        public void Update()
        {
            while (true)
            {
                CurrentState.update();
            }
        }
    }

    public enum State
    {
        Begin,Level1
    }
}
