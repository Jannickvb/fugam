using System.Drawing;

namespace Fugam.Levels.Tile
{
    public class Tile
    {
        public bool Solid { get; set; }
        public int X { get; }
        public int Y { get; }
        public int Id { get; }
        public const int Size = 32;
        private readonly Bitmap _tile;

        public Tile(bool solid, int x, int y, int id)
        {
            Solid = solid;
            X = x;
            Y = y;
            Id = id - 1;
            Bitmap tileset = Properties.Resources.tileset;
            if (Id > 0)
            {
                _tile = tileset.Clone(new Rectangle((Id * Size) % tileset.Width, ((Id * Size) / tileset.Width) * Size, Size, Size), tileset.PixelFormat);
            }
            
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
