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
    public class PacketPlayers : Packet
    {
        public List<FugamID> playerIDs { get; }
         
        public PacketPlayers(FugamID id,List<FugamID> playerids ) : base(id)
        {
            playerIDs = playerids;
        }

        public override void HandleClientSide(IClient clientInterface)
        {
            clientInterface.ReceivePacketPlayers(this);
        }
    }
}
