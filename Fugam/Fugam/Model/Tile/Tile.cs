using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fugam.Model.Tile
{
    public class Tile
    {
        public const int SIZE = 32;
        private bool isSolid;
        public int x { get; }
        public int y { get; }
        public int id { get; }

        private Bitmap tileset;
        private Bitmap tile;
        private Rectangle rect;

        public Tile(bool isSolid, int x, int y, int id)
        {
            this.isSolid = isSolid;
            this.x = x;
            this.y = y;
            this.id = id;

            //get tileset

            id--;

        }
    }
}
