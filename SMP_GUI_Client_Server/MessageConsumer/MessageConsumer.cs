using System;
using System.IO;
using System.Net.Sockets;
using SMP_Library;
using CryptographyUtilities;
using System.Net;

namespace SMPClientConsumer
{
    internal class MessageConsumer
    {
        public static event EventHandler<SMPResponsePacketEventArgs> SMPResponsePacketRecieved;

        public static void SendSmpPacket(string serverIpAddress, int port, SmpPacket smpPacket, string privateKey)
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

                string decrypted = Decrypt(responsePacket, privateKey);

                Console.WriteLine(responsePacket);
                ProcessSmpResponsePacket(responsePacket);
            }
            catch (Exception ex)
            {
                ProcessSmpResponsePacket("CONNECTION_ERROR");
            }
        }

        private static string Decrypt(string responsePacket, string privateKey)
        {
            try
            {
                // this checks if we get the message or not
                if (responsePacket.StartsWith("Message Information:"))
                {
                    // get encrypted message
                    string[] lines = responsePacket.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    if (lines.Length >= 3)
                    {
                        string dateTime = lines[1];
                        string encryptedMessage = lines[2];
                        string decrypted = Encryption.DecryptMessage(encryptedMessage, privateKey);
                        // reconstruct after splitting
                        return "Message Information:" + Environment.NewLine + dateTime + Environment.NewLine + decrypted + Environment.NewLine;
                    }
                }
                return responsePacket;
            }
            catch (Exception ex)
            {
                return "DECRYPTION_ERROR" + ex.Message;
            }
        }

		private static void ProcessSmpResponsePacket(string responsePacket)
        {
            SMPResponsePacketEventArgs eventArgs = new SMPResponsePacketEventArgs(responsePacket);

            if (SMPResponsePacketRecieved != null) SMPResponsePacketRecieved(null, eventArgs);
        }
    }
}
