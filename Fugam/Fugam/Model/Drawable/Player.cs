
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fugam.Levels.Tile;
using FugamUtil.Identifier;

namespace Fugam.Model.Drawable
{
    public class Player: Entity
    {

        public int x { get; set; }
        public int y { get; set; }
        public FugamID fid { get; }
        private Animation animation;
        private Bitmap currentImage;

        public Player(FugamID id,TileMap tilemap):base(tilemap)
        {
            fid = id;
            y = 11;
            
            switch (fid.GameID)
            {
                case 0:
                    x = 4;
                    animation = new Animation(Properties.Resources.playerred, 32, 32, 55);
                    break;
                case 1:
                    x = 10;
                    animation = new Animation(Properties.Resources.playerblue, 32, 32, 65);
                    break;
            }
            currentImage = animation.GetCurrentImage();
        }

        public override void Init()
        {}

        public override void Update()
        {
            animation.Update();
            currentImage = animation.GetCurrentImage();
        }

        public override void Draw(Graphics g)
        {
            /* debug
            Brush fillBrush = null;
            switch (fid.GameID)
            {
                case 0:
                    fillBrush = Brushes.Blue;
                    break;
                case 1:
                    fillBrush = Brushes.Red;
                    break;
                default:
                    fillBrush = Brushes.Purple;
                    break;

            }
            g.FillRectangle(fillbrush, x * Tile.Size, y * Tile.Size, Tile.Size, Tile.Size);
            */

            g.DrawImage(currentImage, new PointF(x * Tile.Size, y * Tile.Size));
        }
    }
}
