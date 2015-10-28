using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FugamUtil.Identifier;
using FugamUtil.Interface;

namespace FugamUtil.Packets
{
    [Serializable]
    public abstract class Packet
    {
        public FugamID FugamId { get; }

        protected Packet(FugamID id)
        {
            FugamId = id;
        }

        public virtual void HandleClientSide(IClient clientInterface)
        { }

        public virtual void HandleServerSide(IServer serverInterface)
        { }
    }
}
