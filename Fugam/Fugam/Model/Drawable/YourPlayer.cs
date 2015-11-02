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
    public class YourPlayer : Player
    {
        public bool isMoving { get; set; }

        public YourPlayer(FugamID id, TileMap tm) : base(id,tm)
        {
            
        }
        
        public override void Init()
        {

        }

        public override void Update()
        {

        }

        public void Right()
        {
            x += 1;
        }

        public void Left()
        {
            x -= 1;
        }

        public void Up()
        {
            y -= 1;
        }

        public void Down()
        {
            y += 1;
        }
    }
}
