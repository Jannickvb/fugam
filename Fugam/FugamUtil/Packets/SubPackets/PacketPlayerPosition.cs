using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FugamUtil.Identifier;
using FugamUtil.Interface;

namespace FugamUtil.Packets.SubPackets
{
    [Serializable]
    public class PacketPlayerPosition : Packet
    {
        public int X { get; }
        public int Y { get; }

        public PacketPlayerPosition(FugamID id,int x, int y) : base(id)
        {
            X = x;
            Y = y;
        }

        public override void HandleServerSide(IServer serverInterface)
        {
            serverInterface.ReceivePacketPlayerPosition(this);
        }

        public override void HandleClientSide(IClient clientInterface)
        {
            clientInterface.ResponePacketPlayerPosition(this);
        }
    }
}
