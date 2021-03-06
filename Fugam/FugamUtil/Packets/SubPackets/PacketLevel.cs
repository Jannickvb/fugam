﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FugamUtil.Identifier;
using FugamUtil.Interface;

namespace FugamUtil.Packets.SubPackets
{
    [Serializable]
    public class PacketLevel : Packet
    {
        public string NewLevelId { get; }

        public PacketLevel(FugamID id, string levelid):base(id)
        {
            NewLevelId = levelid;
        }

        public override void HandleClientSide(IClient clientInterface)
        {
            clientInterface.ReceivePacketLevel(this);
        }
    }
}
