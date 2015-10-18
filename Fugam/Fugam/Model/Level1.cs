using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fugam.Control;
using FugamUtil;
namespace Fugam.Model
{
    class Level1 : GameState
    {
        private double _x = 0;
        public Level1(GameStateManager gsm) : base(gsm)
        {
            
        }

        public override void keyPressed(Keys k)
        {
            switch (k)
            {
                case Keys.W:
                    break;
                case Keys.A:
                    gsm.SetState(State.Begin);
                    break;
                case Keys.S:
                    break;
                case Keys.D:
                    break;
            }
        }

        public override void keyReleased(Keys k)
        {
            
        }

        public override void init()
        {
            
        }

        public override void update()
        {
            _x = (double)ServerIO.Recieve(gsm.Client.GetStream());
        }

        public override void draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Aqua), (int)_x, 50, 100, 100);
        }
    }
}
