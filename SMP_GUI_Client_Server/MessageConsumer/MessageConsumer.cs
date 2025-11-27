using System;
using System.IO;
using System.Net.Sockets;
using SMP_Library;

namespace SMPClientConsumer
{
    internal class MessageConsumer
    {
        public static event EventHandler<SMPResponsePacketEventArgs> SMPResponsePacketRecieved;

        public static void SendSmpPacket(string serverIpAddress, int port, SmpPacket smpPacket)
        {
            try
            {
                TcpClient client = new TcpClient(serverIpAddress, port);
                NetworkStream networkStream = client.GetStream();

                //Send the SMP packet
                StreamWriter writer = new StreamWriter(networkStream);
                writer.WriteLine(smpPacket);
                writer.Flush();

                //Receive SMP Response from server
                StreamReader reader = new StreamReader(networkStream);
                string responsePacket = reader.ReadToEnd().Trim();

                //Done with the server
                reader.Close();
                writer.Close();
                Console.WriteLine(responsePacket);
                ProcessSmpResponsePacket(responsePacket);
            }
            catch (Exception ex)
            {
                ProcessSmpResponsePacket("CONNECTION_ERROR");
            }
        }

        private static void ProcessSmpResponsePacket(string responsePacket)
        {
            SMPResponsePacketEventArgs eventArgs = new SMPResponsePacketEventArgs(responsePacket);

            if (SMPResponsePacketRecieved != null) SMPResponsePacketRecieved(null, eventArgs);
        }
    }
}
