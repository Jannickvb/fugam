using System;
using System.Drawing;

namespace Fugam.Levels.Tile
{
    public class Obstacle : Tile
    {
        public bool Activated { get; set; }

        public int ObstracleID { get; }
        private Tile _notActiveTile;

        public Obstacle(int x, int y, string id) : base(true, x, y, "42")
        {
            ObstracleID = int.Parse(id);
            Activated = false;
            _notActiveTile = new Tile(false,x,y,"89");
        }

        public override string ToString()
        {
            return "Obstracle: " + ObstracleID + " - " + GetHashCode();
        }

        public override void DrawTile(Graphics g)
        {
            if (!Activated)
            {
                base.DrawTile(g);
            }
            else
            {
               _notActiveTile.DrawTile(g);      
            }
        }
    }
}
