using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace FugamUtil
{
    [Serializable]
    public class Level
    {
        Font font = new Font("Arial",16);
        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Aqua,0,0,100,100);
            g.DrawString("Dit is je nieuwe level",font,Brushes.Black,50 - font.Size/2,50-font.Size/2);
        }
    }
}
