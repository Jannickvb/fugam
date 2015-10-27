using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fugam.Control;
using Fugam.Properties;
using Fugam.Assets;

namespace Fugam.Model
{
    class BeginState : GameState
    {
        private string[] menuItems = {"Start" , "Exit"};
        private int menuIndex = 0;
        private Bitmap background;

        public BeginState(GameStateManager gsm) : base(gsm)
        {
            background = new Bitmap(Resources.titlescreen);
        }

        public override void keyPressed(Keys k)
        {
           
        }

        public override void keyReleased(Keys k)
        {
            switch (k)
            {
                case Keys.Enter:
                    switch (menuIndex)
                    {
                        case 0:
                            gsm.ConnectServer();
                            gsm.SetState(State.Level1);
                            break;
                        case 1:
                            Application.Exit();
                            break;
                    }
                    break;
                case Keys.Up:
                    menuIndex--;
                    if (menuIndex == -1)
                    {
                        menuIndex = menuItems.Length - 1;
                    }
                    break;
                case Keys.Down:
                    menuIndex++;
                    if (menuIndex == menuItems.Length)
                    {
                        menuIndex = 0;
                    }
                    break;
            }

        }

        public override void init()
        {

        }

        public override void update()
        {
            //Console.WriteLine("Begin state!!");
        }

        public override void draw(Graphics g)
        {
            //g.DrawImage(background, 0, 0, gsm.PANEL_WIDTH, gsm.PANEL_HEIGHT);
            g.DrawImage(background, 0, 0, 800, 565);

            for(int i = 0; i < menuItems.Length; i++)
            {
                if(i == menuIndex)
                {
                    g.DrawString(menuItems[i], gsm.GAME_FONT, CustomBrushes.BRUSH_MENU_HIGHLIGHT, 100, (i*100)+300);
                }
                else
                {
                    g.DrawString(menuItems[i], gsm.GAME_FONT, CustomBrushes.BRUSH_MENU_REGULAR, 100, (i * 100) + 300);
                }
            }
            
        }
    }
}
