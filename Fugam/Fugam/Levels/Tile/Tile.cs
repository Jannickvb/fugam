using System.Drawing;

namespace Fugam.Levels.Tile
{
    public class Tile : IDraw
    {
        public bool Solid { get; set; }
        /// <summary>
        /// De x van de tile map
        /// </summary>
        public int X { get; }
        /// <summary>
        /// De y van de tile map
        /// </summary>
        public int Y { get; }
        public Brush Brush { get; set; }
        private readonly Pen _pen;
        public const int TileWidth = 32;
        public const int TileHeight = 32;
        public Tile(bool solid, int x, int y)
        {
            Solid = solid;
            X = x;
            Y = y;
            Brush = Brushes.Black;
            _pen = Pens.Black;
        }

        public virtual void DrawTile(Graphics g)
        {
            if (Solid)
            {
                g.FillRectangle(Brush, X*TileWidth, Y*TileHeight, TileWidth, TileHeight);
            }
            else
            {
                g.DrawRectangle(_pen, X*TileWidth, Y*TileHeight, TileWidth, TileHeight);
            }
        }
    }
}
