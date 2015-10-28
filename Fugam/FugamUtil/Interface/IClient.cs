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
        void ReceivePacketFugamID(PacketFugamID fid);
        void ReceivePacketLevel(PacketLevel level);
        void ReceivePacketPlayers(PacketPlayers pp);
        void ResponePacketPlayerPosition(PacketPlayerPosition ppp);
    }
}
