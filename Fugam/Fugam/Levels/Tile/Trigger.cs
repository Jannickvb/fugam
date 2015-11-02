using System;
using System.Drawing;
using Fugam.Model.Drawable;

namespace Fugam.Levels.Tile
{
    public class Trigger : Tile
    {
        public Obstacle Obstacle { get; set; }

        public int TriggerID { get; }

        public Trigger(int x, int y, string id) : base(false, x, y, "157")
        {
            TriggerID = int.Parse(id);
        }

        public bool PlayerOnTile(Player p)
        {
            //Console.WriteLine("Player: "+p.fid+"\tX: "+p.x+"\tY: "+p.y);
            //Console.WriteLine("Tile: X:"+X/Size+"\tY: "+Y/Size);
            return p.x == (X/Size) && p.y == (Y/Size);
        }

        public void Activate()
        {
            Obstacle.Activated = true;
        }

        public void DeActivate()
        {
            Obstacle.Activated = false;
        }

        public override string ToString()
        {
            return "Trigger: " + TriggerID + " - " + GetHashCode();
        }
    }
}
