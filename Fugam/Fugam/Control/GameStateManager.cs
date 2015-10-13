using Fugam.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fugam.View;

namespace Fugam.Control
{
    public class GameStateManager
    {
        public int PANEL_WIDTH { get; }
        public int PANEL_HEIGHT { get; }

        private readonly List<GameState> _GameStateList;
        public GameState CurrentState { get; set; }

        public Font GAME_FONT { get; }
        public Brush GAME_STRING_BRUSH { get; }

        private GEngine _gEngine;

        public GameStateManager(int width, int height)
        {
            PANEL_WIDTH = width;
            PANEL_HEIGHT = height;
            GAME_FONT = new Font("Arial",16);
            GAME_STRING_BRUSH = new SolidBrush(Color.Red);

            _GameStateList = new List<GameState>();
            _GameStateList.Add(new BeginState(this));
            _GameStateList.Add(new Level1(this));

            SetState(State.Begin);
        }

        public void StartGame(Graphics g)
        {
            _gEngine = new GEngine(this,g);
            _gEngine.Init();
        }

        public void StopGame()
        {
            _gEngine.Stop();
        }

        public void SetState(State s)
        {
            switch (s)
            {
                case State.Begin:
                    CurrentState = _GameStateList.ElementAt(0);
                    break;
                case State.Level1:
                    CurrentState = _GameStateList.ElementAt(1);
                    break;
            }
            CurrentState.init();
        }
    }

    public enum State
    {
        Begin,Level1
    }
}
