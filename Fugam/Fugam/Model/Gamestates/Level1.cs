using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fugam.Assets;
using Fugam.Control;
using Fugam.Levels;
using Fugam.Model.Drawable;
using FugamUtil;
using FugamUtil.Packets.SubPackets;
using Fugam.Levels.Tile;
using FugamUtil.Packets;

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
                    break;
                case Keys.S:
                    break;
                case Keys.D:
                    break;
            }
        }

        public override void keyReleased(Keys k)
        {
            switch (k)
            {
                case Keys.W:
                    player.Up();
                    break;
                case Keys.A:
                    player.Left();
                    break;
                case Keys.S:
                    player.Down();
                    break;
                case Keys.D:
                    player.Right();
                    break;
            }
        }

        public override void init()
        {
            
        }

        public override void update()
        {
            if (player != null)
            {
                ServerIO.Send(gsm.Client.GetStream(), new PacketPlayerPosition(gsm.FugamId, player.x, player.y));
            }
            //if (gsm.FugamId != null)
            //{
            //    Console.WriteLine(gsm.FugamId + "\twaiting for packet\t"+DateTime.Now);
            //}
            ServerIO.Recieve(gsm.Client.GetStream()).HandleClientSide(this);
            if (_otherPlayers != null && player != null)
            {
                _level.CheckTriggers(player,_otherPlayers);
                foreach(Player otherplayer in _otherPlayers)
                {
                    otherplayer.Update();
                }
                player.Update();
            }
            //Console.WriteLine(gsm.FugamId + "\tpacket received\t" + DateTime.Now);
        }
        
        public override void draw(Graphics g)
        {
            _level?.Draw(g);
            player?.Draw(g);

            if (_otherPlayers != null)
            {
                foreach (Player otherPlayer in _otherPlayers)
                {
                    otherPlayer.Draw(g);
                }
            }
        }

        public override void ReceivePacketFugamID(PacketFugamID fid)
        {
            gsm.FugamId = fid.FugamId;
        }

        public override void ReceivePacketLevel(PacketLevel pl)
        {
            _level = new Level(pl.NewLevelId);
        }

        public override void ReceivePacketPlayers(PacketPlayers pp)
        {
            player = new YourPlayer(gsm.FugamId,_level.TileMap,_level.CollisonMap);

            _otherPlayers = new Player[pp.playerIDs.Count-1];

            int opp = 0;
            for (int i = 0; i < pp.playerIDs.Count; i++)
            {
                if (!pp.playerIDs.ElementAt(i).Equals(gsm.FugamId))
                {
                    _otherPlayers[opp] = new Player(pp.playerIDs.ElementAt(i),_level.TileMap);
                    opp++;
                }
            }
        }
        
        public override void ResponePacketPlayerPosition(PacketPlayerPosition ppp)
        {
            foreach (Player p in _otherPlayers)
            {
                if (p.fid.Equals(ppp.FugamId))
                {
                    p.x = ppp.X;
                    p.y = ppp.Y;
                    break;
                } 
            }
        }
    }
}
