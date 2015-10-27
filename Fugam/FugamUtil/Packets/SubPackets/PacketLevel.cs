﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FugamUtil.Interface;

namespace FugamUtil.Packets.SubPackets
{
    [Serializable]
    public class PacketLevel : Packet
    {
        public Level NewLevel { get; }

        public PacketLevel(Level level)
        {
            NewLevel = level;
        }

        public override void HandleClientSide(IClient clientInterface)
        {
            clientInterface.ReceivePacketLevel(this);
        }
    }
}
