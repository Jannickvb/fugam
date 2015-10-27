using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FugamUtil.Interface;

namespace FugamUtil.Packets.SubPackets
{
    [Serializable]
    public class PacketPlayers : Packet
    {
        public List<int> IdPlayers { get; set; }

        public PacketPlayers(int yourId) : base(yourId)
        {
        }

        public override void HandleClientSide(IClient clientInterface)
        {
            clientInterface.ReceivePacketPlayers(this);
        }
    }
}
