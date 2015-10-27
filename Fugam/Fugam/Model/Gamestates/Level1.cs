using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fugam.Control;
using Fugam.Levels;
using FugamUtil;
using FugamUtil.Packets.SubPackets;
using Fugam.Levels.Tile;

namespace Fugam.Model
{
    class Level1 : GameState
    {
        private Level _level;

        public Level1(GameStateManager gsm) : base(gsm)
        {
            
        }

        public override void keyPressed(Keys k)
        {
            switch (k)
            {
                case Keys.W:
                    break;
                case Keys.A:
                    gsm.SetState(State.Begin);
                    break;
                case Keys.S:
                    break;
                case Keys.D:
                    break;
            }
        }

        public override void keyReleased(Keys k)
        {
            
        }

        public override void init()
        {
            
        }

        public override void update()
        {
            ServerIO.Recieve(gsm.Client.GetStream()).HandleClientSide(this);   
        }

        public override void draw(Graphics g)
        {
            if (_level != null)
            {
                _level.Draw(g);
            }
        }

        public override void ReceivePacketLevel(PacketLevel pl)
        {
            _level = new Level(new TileMap(LevelIO.GetLevel(pl.NewLevelId),false));
            ServerIO.Send(gsm.Client.GetStream(),new PacketLevelRespone(true));
        }
    }
}
