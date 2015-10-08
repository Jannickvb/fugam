using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fugam
{
    public class MainPanel : Panel
    {
        private Graphics g;

        public MainPanel():base()
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "mainPanel";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
        }
    }
}
