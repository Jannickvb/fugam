using Fugam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fugam.Control
{
    public class GameStateManager
    {
        public List<GameState> GameStateList { get; set; }
        
        public GameStateManager()
        {
            GameStateList = new List<GameState>();
        }
    }
}
