using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FugamUtil.Interface;

namespace FugamUtil.Packets
{
    [Serializable]
    public class Packet
    {
        public int ClientId { get; }

        public Packet(int id)
        {
            ClientId = id;
        }

        public virtual void HandleClientSide(IClient clientInterface)
        {
            clientInterface.ReceivePacket(this);
        }

        public virtual void HandleServerSide(IServer serverInterface)
        { }
    }
}
