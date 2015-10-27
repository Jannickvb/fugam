using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FugamUtil.Interface;

namespace FugamUtil.Packets.SubPackets
{
    [Serializable]
    public class PacketLevelRespone : Packet
    {
        public bool Received { get; }

        public PacketLevelRespone(bool received)
        {
            Received = received;
        }

        public override void HandleServerSide(IServer serverInterface)
        {
            serverInterface.ResponsePacketLevel(this);
        }
    }
}
