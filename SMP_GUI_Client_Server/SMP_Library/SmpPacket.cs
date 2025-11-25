using System;

namespace SMP_Library
{
    public class SmpPacket
    {
        public string Version;
        public string MessageType;
        public string Priority;
        public string DateTime;
        public string Message;

        public SmpPacket(string version, string messageType, string priority, string dateTime, string message)
        {
            Version = version;
            MessageType = messageType;
            Priority = priority;
            DateTime = dateTime;
            Message = message;
        }

        public override string ToString()
        {
            string packet = Version + Environment.NewLine;
            packet += MessageType + Environment.NewLine;
            packet += Priority + Environment.NewLine;
            packet += DateTime + Environment.NewLine;
            packet += Message + Environment.NewLine;

            return packet;
        }
    }
}
