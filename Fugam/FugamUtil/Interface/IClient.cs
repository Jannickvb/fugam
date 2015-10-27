using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FugamUtil.Packets;
using FugamUtil.Packets.SubPackets;

namespace FugamUtil.Interface
{
    public interface IClient
    {
        void ReceivePacketLevel(PacketLevel level);
        void ReceivePacket(Packet packet);
        void ResponePacketOtherPlayerPosition(PacketPlayerPosition popp);
        void ReceivePacketPlayers(PacketPlayers pop);
    }
}
