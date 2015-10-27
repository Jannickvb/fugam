using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fugam.Control;
using Fugam.Levels;
using Fugam.Model.Drawable;
using FugamUtil;
using FugamUtil.Packets.SubPackets;

namespace Fugam.Model
{
    class Level1 : GameState
    {
        private Level _level;
        private Player[] _otherPlayers;
        private YourPlayer player;
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
            if (player != null && _otherPlayers != null)
            {
                ServerIO.Send(gsm.Client.GetStream(),new PacketPlayerPosition(gsm.ServerClientID,player.x,player.y));
            }  
        }

        public override void draw(Graphics g)
        {
            if (_level != null)
            {
                _level.Draw(g);
            }
            if (player != null)
            {
                player.draw(g);
            }
            if (_otherPlayers != null)
            {
                foreach (Player p in _otherPlayers)
                {
                    p.draw(g);
                }
            }
        }

        public override void ReceivePacketLevel(PacketLevel pl)
        {
            _level = LevelIO.GetLevel(pl.NewLevelId);
            ServerIO.Send(gsm.Client.GetStream(),new PacketLevelRespone(gsm.ServerClientID,true));
        }

        public override void ResponePacketOtherPlayerPosition(PacketPlayerPosition ppp)
        {
            foreach (Player p in _otherPlayers)
            {
                if (p.Id == ppp.ClientId)
                {
                    p.x = ppp.X;
                    p.y = ppp.Y;
                }
            }
        }

        public override void ReceivePacketPlayers(PacketPlayers pop)
        {
            player = new YourPlayer(gsm.ServerClientID,_level.TileMap);
            _otherPlayers = new Player[pop.IdPlayers.Count-1];
            for (int i = 0; i < _otherPlayers.Length; i++)
            {
                if(pop.IdPlayers.ElementAt(i) != gsm.ServerClientID)
                _otherPlayers[i] = new Player(pop.IdPlayers.ElementAt(i),_level.TileMap);
            }
        }
    }
}
