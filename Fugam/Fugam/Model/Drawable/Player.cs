
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

        public Player(FugamID id,TileMap tilemap):base(tilemap)
        {
            fid = id;
            y = 11;
            switch (fid.GameID)
            {
                case 0:
                    x = 4;
                    break;
                case 1:
                    x = 10;
                    break;
            }
        }

        public override void Init()
        {}

        public override void Update()
        {}

        public override void Draw(Graphics g)
        {
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
            g.FillRectangle(fillBrush,x*Tile.Size,y*Tile.Size,Tile.Size,Tile.Size);
        }
    }
}
