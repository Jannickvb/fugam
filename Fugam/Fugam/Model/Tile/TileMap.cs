using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fugam.Model.Tile
{
    public class TileMap
    {
        private int[][] tilemap;
        private Tile[,] tiles;
        public int x, y;
        public bool collisionMap;

        public TileMap(int[][] map, bool collisionMap)
        {
            this.tilemap = map;
            this.y = tilemap[0].Length;
            this.x = tilemap.Length;
            this.collisionMap = collisionMap;
            tiles = new Tile[x,y];
        }

        private void loadTiles(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                for (int k = 0; k < x; k++)
                {
                    if (collisionMap)
                    {
                        if (tilemap[k][i] != 0)
                            tiles[k,i] = new Tile(true, i * Tile.SIZE, k * Tile.SIZE, tilemap[k][i]);
                        else
                            tiles[k,i] = new Tile(false, i * Tile.SIZE, k * Tile.SIZE, tilemap[k][i]);
                    }
                    else
                    {
                        tiles[k,i] = new Tile(false, i * Tile.SIZE, k * Tile.SIZE, tilemap[k][i]);
                    }
                }
            }
        }
    }
}
