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

        private TileMap _collisonMap;

        public YourPlayer(FugamID id, TileMap tm,TileMap collisionMap) : base(id,tm)
        {
            _collisonMap = collisionMap;
        }
        
        public override void Init()
        {

        }

        public override void Update()
        {

        }

        //true == x, false == y
        private void CheckCollision(bool xOry, int value)
        {
            int newXValue = x;
            int newYValue = y;

            if (xOry)
            {
                newXValue += value;
            }
            else
            {
                newYValue += value;
            }

            if (newXValue >= 0 && newXValue < _collisonMap.width && newYValue >= 0 && newYValue < _collisonMap.height)
            {
                bool collision = false;
                foreach (Obstacle b in _collisonMap.Obstacles)
                {
                    if ((b.X/32) == newXValue && (b.Y/32) == newYValue && !b.Activated)
                    {
                        collision = true;
                        break;
                    }
                }
                //als er nog een collision is, misschien dan bij de muur ofzo hihi

                if (!collision)
                {
                    collision = _collisonMap.getTileMap()[newYValue, newXValue].Solid;
                    //if (_collisonMap.getTileMap()[newYValue, newXValue].Solid)
                    //{
                    //    collision = true;
                    //}
                }

                if (!collision)
                {
                    x = newXValue;
                    y = newYValue;
                }
            }
        }

        public void Right()
        {
            CheckCollision(true,1);
        }

        public void Left()
        {
            CheckCollision(true,-1);
        }

        public void Up()
        {
            CheckCollision(false,-1);
        }

        public void Down()
        {
            CheckCollision(false,1);
        }
    }
}
