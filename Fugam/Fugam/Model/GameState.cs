using Fugam.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fugam.Model
{
    public abstract class GameState
    {
        private GameStateManager gsm;

        public GameState(GameStateManager gsm)
        {
            this.gsm = gsm;
        }
        protected abstract void keyPressed(int k);
        protected abstract void keyReleased(int k);
        protected abstract void init();
        protected abstract void update();
        protected abstract void draw();
    }
}
