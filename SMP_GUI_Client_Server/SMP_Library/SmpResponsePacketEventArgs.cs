using System;

namespace SMP_Library
{
    public class SMPResponsePacketEventArgs : EventArgs
    {
        public string ResponseMessage;

        public SMPResponsePacketEventArgs(string responseMessage)
        {
            ResponseMessage = responseMessage;
        }
    }
}
