using Fugam.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FugamUtil.Interface;
using FugamUtil.Packets;
using FugamUtil.Packets.SubPackets;

namespace Fugam.Model
{
    public abstract class GameState : IClient
    {
        public GameStateManager gsm { get; }

        public GameState(GameStateManager gsm)
        {
            this.gsm = gsm;
        }
        public abstract void keyPressed(Keys k);
        public abstract void keyReleased(Keys k);
        public abstract void init();
        public abstract void update();
        public abstract void draw(Graphics g);
        public virtual void ReceivePacketLevel(PacketLevel pl)
        { }

        public void ReceivePacket(Packet packet)
        {
            gsm.ServerClientID = packet.ClientId;
        }
        public virtual void ResponePacketOtherPlayerPosition(PacketPlayerPosition ppp)
        { }
        public virtual void ReceivePacketPlayers(PacketPlayers pop)
        { }
    }
}
