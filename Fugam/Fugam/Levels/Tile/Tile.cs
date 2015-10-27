using System.Drawing;

namespace Fugam.Levels.Tile
{
    public class Tile
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
        public int Id { get; }
        public Brush Brush { get; set; }
        private readonly Pen _pen;
        public const int Size = 32;
        private Bitmap _tile;

        public Tile(bool solid, int x, int y, int id)
        {
            Solid = solid;
            X = x;
            Y = y;
            Id = id - 1;
            Bitmap tileset = Properties.Resources.tileset;
            Rectangle subImagerect = new Rectangle((Id*Size)%tileset.Width, ((Id*Size)/tileset.Width)*Size, Size, Size);
            if (Id > 0)
            {
                _tile = tileset.Clone(subImagerect, tileset.PixelFormat);
            }
            
            Brush = Brushes.Black;
            _pen = Pens.Black;
        }

        public virtual void DrawTile(Graphics g)
        {
            if (_tile != null)
            {
                g.DrawImage(_tile,X,Y);
            }
        }
    }
}
