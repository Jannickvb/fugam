using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fugam.Control;

namespace Fugam.View
{
    class GEngine
    {
        private readonly GameStateManager _gsm;
        private readonly Graphics _panelGraphics;

        private Thread _drawThread;

        private Brush _background;

        public GEngine(GameStateManager gsm,Graphics graphics)
        {
            this._gsm = gsm;
            this._panelGraphics = graphics;
        }

        public void Init()
        {
            _background =  new SolidBrush(Color.White);
            
            _drawThread = new Thread(new ThreadStart(Draw));
            _drawThread.Start();
        }

        public void Stop()
        {
            _drawThread.Abort();
        }

        private void Draw()
        {
            int framesDrawed = 0, fps = 0;
            long startTime = Environment.TickCount;

            Bitmap drawMap = new Bitmap(_gsm.PANEL_WIDTH,_gsm.PANEL_HEIGHT);
            Graphics drawGraphics = Graphics.FromImage(drawMap);

            while (true)
            {
                //background
                drawGraphics.FillRectangle(_background,0,0,_gsm.PANEL_WIDTH,_gsm.PANEL_HEIGHT);

                //current state drawing
                _gsm.CurrentState.draw(drawGraphics);

                //frames per second
                string txt = fps + "";
                if (_gsm.FugamId != null)
                {
                    txt += "\n" + _gsm.FugamId.ToString();
                }
                drawGraphics.DrawString(txt,_gsm.GAME_FONT,Assets.CustomBrushes.BRUSH_MENU_HIGHLIGHT,0,0);

                //draw the drawmap
                _panelGraphics.DrawImage(drawMap,0,0);

                framesDrawed++;
                if (Environment.TickCount >= startTime + 1000)
                {
                    fps = framesDrawed;
                    framesDrawed = 0;
                    startTime = Environment.TickCount;
                }
            }
        }
    }
}
