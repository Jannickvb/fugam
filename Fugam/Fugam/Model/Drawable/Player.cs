
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
        public int Id { get; }

        public Player(int id,TileMap tilemap):base(tilemap)
        {
            Id = id;
            this.x = x;
            this.y = y;
        }

        public override void init()
        {}

        public override void update()
        {}

        public override void draw(Graphics g)
        {
            g.FillRectangle(Brushes.Blue,x,y,50,50);
        }
    }
}
