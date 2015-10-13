using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fugam.Control;

namespace Fugam.Model
{
    class BeginState : GameState
    {
        private string _beginString;

        public BeginState(GameStateManager gsm) : base(gsm)
        {
            
        }

        public override void keyPressed(Keys k)
        {
            switch (k)
            {
                
            }
        }

        public override void keyReleased(Keys k)
        {
            switch (k)
            {
                case Keys.Enter:
                    gsm.SetState(State.Level1);
                    break;
            }
        }

        public override void init()
        {
            _beginString = "Press enter to begin";
        }

        public override void update()
        {
            throw new NotImplementedException();
        }

        public override void draw(Graphics g)
        {
            g.DrawString(_beginString,gsm.GAME_FONT,gsm.GAME_STRING_BRUSH,100,100);
        }
    }
}
