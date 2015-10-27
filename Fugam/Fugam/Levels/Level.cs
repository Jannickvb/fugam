using System.Drawing;
using Fugam.Levels.Tile;


namespace Fugam.Levels
{
    public class Level
    {
        public TileMap TileMap { get; }

        public Level(TileMap tm)
        {
            TileMap = tm;
        }

        public void Draw(Graphics g)
        {
            TileMap.DrawTiles(g);
        }
    }
}
