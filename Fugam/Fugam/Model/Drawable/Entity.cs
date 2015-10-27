
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fugam.Levels.Tile;

namespace Fugam.Model
{
    public abstract class Entity
    {

        protected TileMap tilemap { get; set; }

        public Entity(TileMap tilemap)
        {
            this.tilemap = tilemap;
        }

        public abstract void init();
        public abstract void draw(Graphics g);
        public abstract void update();
    }
}
