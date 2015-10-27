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
        public virtual void HandleClientSide(IClient clientInterface)
        { }

        public virtual void HandleServerSide(IServer serverInterface)
        { }
    }
}
