using System;

namespace SMP_Library
{
    public class SmpPacket
    {
        public string Version;
        public string UserID;
        public string Password;
        public string MessageType;
        public string Priority;
        public string DateTime;
        public string Message;

        public SmpPacket(string version, string messageType, string userID, string password, string priority, string dateTime, string message)
        {
            Version = version;
            UserID = userID;
            Password = password;
            MessageType = messageType;
            Priority = priority;
            DateTime = dateTime;
            Message = message;
        }

        public override string ToString()
        {
            string packet = Version + Environment.NewLine;
            packet += MessageType + Environment.NewLine;
            packet += UserID + Environment.NewLine;
            packet += Password + Environment.NewLine;
            packet += Priority + Environment.NewLine;
            packet += DateTime + Environment.NewLine;
            packet += Message + Environment.NewLine;

            return packet;
        }
    }
}
