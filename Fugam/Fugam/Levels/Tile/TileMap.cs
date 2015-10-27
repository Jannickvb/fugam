using System.Drawing;
using System.Windows.Forms;

namespace Fugam.Levels.Tile
{
    public class TileMap
    {
        private int[,] _tileIds;
        private Tile[,] _tiles;
        public int ArrayWidth { get; }
        public int ArrayHeight { get; }
        public bool IsCollisonMap { get; }

        public TileMap(int[,] tileIds,bool collisonMap,Bitmap tileset)
        {
            _tileIds = tileIds;
            ArrayWidth = _tileIds.GetLength(0);
            ArrayHeight = _tileIds.GetLength(1);
            _tiles = new Tile[ArrayWidth,ArrayHeight];
            IsCollisonMap = collisonMap;
            LoadTiles(ArrayWidth,ArrayHeight,tileset);
        }

        private void LoadTiles(int width, int height,Bitmap tileset)
        {
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    if (IsCollisonMap)
                    {
                        //bool solid;
                        //if (_tileIds[k][i] != 0)
                        //{
                        //    solid = true;
                        //}
                        //else
                        //{
                        //    solid = false;
                        //}
                        _tiles[k, i] = new Tile(_tileIds[k,i] != 0, i*Tile.Size, i*Tile.Size, _tileIds[k,i]);
                    }
                    else
                    {
                        _tiles[k, i] = new Tile(false, i * Tile.Size, i * Tile.Size, _tileIds[k,i]);
                    }
                }
            }
        }

        public void DrawTiles(Graphics g)
        {
            for (int i = 0; i < ArrayHeight; i++)
            {
                for (int k = 0; k < ArrayWidth; k++)
                {
                    _tiles[k,i].DrawTile(g);
                }
            }
        }
    }
}
