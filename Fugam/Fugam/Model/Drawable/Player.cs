
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fugam.Levels.Tile;

namespace Fugam.Model.Drawable
{
    public class Player: Entity
    {

        public int x { get; set; }
        public int y { get; set; }
        public bool isMoving { get; set; }

        public Player(int x, int y,TileMap tilemap):base(tilemap){
            this.x = x;
            this.y = y;
        }

        public override void init()
        {

        }

        public override void draw(Graphics g)
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
