using System;
using SMP_Library;

namespace SMP_Library
{
    public class PacketEventArgs : EventArgs
    {
        public SmpPacket SmpPacket;

        public PacketEventArgs(SmpPacket smpPacket)
        {
           SmpPacket = smpPacket;
        }
    }
}
