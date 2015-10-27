using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fugam.Levels.Tile;

namespace Fugam.Model.Drawable
{
    class YourPlayer : Player
    {
        public bool isMoving { get; set; }

        public YourPlayer(int id, TileMap tm) : base(id,tm)
        {
            
        }

        public override void draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red,x,y,50,50);
        }

        public override void init()
        {

        }

        public override void update()
        {

        }

        public void keyPressed(int keyCode)
        {

        }

        public void keyReleased(int keyCode)
        {

        }
    }
}
