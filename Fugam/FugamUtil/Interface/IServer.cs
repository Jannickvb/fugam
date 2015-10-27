using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FugamUtil.Packets.SubPackets;

namespace FugamUtil.Interface
{
    public interface IServer
    {
        void ResponsePacketLevel(PacketLevelRespone plr);
        void ReceivePacketPlayerPosition(PacketPlayerPosition ppp);
    }
}
