using System.Drawing;

namespace Fugam.Levels.Tile
{
    public class Trigger : Levels.Tile.Tile
    {
        public Obstacle Obstacle { get; }

        public Trigger(Obstacle ob,int x, int y, Brush brush):base(false,x,y)
        {
            Obstacle = ob;
            Brush = brush;
            ob.Brush = brush;
        }

        public override void DrawTile(Graphics g)
        {
            base.DrawTile(g);
            g.FillRectangle(Brush, X*TileWidth + TileWidth/2, Y*TileHeight + TileHeight/2, TileWidth/2, TileHeight/2);
        }
    }
}
