using System.Drawing;
using Fugam.Levels.Tile;


namespace Fugam.Levels
{
    public class Level : IDraw
    {
        public TileMap TileMap { get; }

        public Level()
        {
            TileMap = new TileMap();
        }

        public bool AddTile(Tile.Tile tile)
        {
            if ((tile.X >= 0 && tile.X < 16) && (tile.Y >= 0 && tile.Y < 16))
            {
                TileMap.Tiles[tile.Y, tile.X] = tile;
                return true;
            }
            return false;
        }

        public void DrawTile(Graphics g)
        {
            TileMap.DrawTile(g);
        }
    }
}
