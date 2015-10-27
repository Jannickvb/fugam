using System.Drawing;

namespace Fugam.Levels.Tile
{
    public class TileMap : IDraw
    {
        public Levels.Tile.Tile[,] Tiles { get; }

        public TileMap()
        {
            Tiles = new Tile[16,16];
        }

        public void DrawTile(Graphics g)
        {
            for(int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    Tiles[y,x].DrawTile(g);
                }
            }
        }
    }
}
