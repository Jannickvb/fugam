using System.Drawing;

namespace Fugam.Levels.Tile
{
    public class Trigger : Tile
    {
        public Obstacle Obstacle { get; set; }

        public Trigger(int x, int y, int id) : base(false, x, y, id)
        {
            
        }

        public void Activate()
        {
            Obstacle.Activated = true;
        }

        public void DeActivate()
        {
            Obstacle.Activated = false;
        }
    }
}
