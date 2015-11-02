using System;

namespace Fugam.Levels.Tile
{
    public class Obstacle : Tile
    {
        public bool Activated { get; set; }
        public Obstacle(int x, int y, int id) : base(true, x, y, id)
        {
            
        }
    }
}
