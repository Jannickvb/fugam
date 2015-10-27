using System.Drawing;
using System.Windows.Forms;

namespace Fugam.Levels.Tile
{
    public class TileMap
    {
        private int[,] tilemap;
        private Tile[,] tiles;
        public int y { get; }
        public int x { get; }
        public bool IsCollisonMap { get; }

        public TileMap(int[,] tilemap,bool collisonMap)
        {
            this.tilemap = tilemap;
            y = tilemap.GetLength(0);
            x = tilemap.GetLength(1);
            tiles = new Tile[x,y];
            IsCollisonMap = collisonMap;
            LoadTiles(x, y);
        }

        private void LoadTiles(int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    if (IsCollisonMap)
                    {
                        if (tilemap[k,i] != 0)
                        {
                            tiles[k, i] = new Tile(true, i * Tile.Size, k * Tile.Size, tilemap[k,i]);
                        }
                        else
                        {
                            tiles[k, i] = new Tile(false, i * Tile.Size, k * Tile.Size, tilemap[k,i]);
                        }
                    }
                    else
                    {
                        tiles[k, i] = new Tile(false, i * Tile.Size, k * Tile.Size, tilemap[k,i]);
                    }
                }
            }
        }

        public Tile[,] getTileMap()
        {
            return tiles;
        }

    }
}
