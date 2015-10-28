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
    public class PacketFugamID : Packet
    {
        public PacketFugamID(FugamID id) : base(id)
        { }

        public override void HandleClientSide(IClient clientInterface)
        {
            clientInterface.ReceivePacketFugamID(this);
        }
    }
}
