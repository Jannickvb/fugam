using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fugam.Control;
using Fugam.Model;

namespace Fugam
{
    public partial class FugamClientForm : Form
    {
        private readonly GameStateManager _gsm;

        public FugamClientForm()
        {
            InitializeComponent();
            _gsm = new GameStateManager(mainPanel.Width,mainPanel.Height);
            Graphics g = mainPanel.CreateGraphics();
            _gsm.StartGame(g);
        }

        private void FugamClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            _gsm.CurrentState.keyPressed(e.KeyCode);
        }

        private void FugamClientForm_KeyUp(object sender, KeyEventArgs e)
        {
            _gsm.CurrentState.keyReleased(e.KeyCode);
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void FugamClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _gsm.StopGame();
        }
    }
}
