using SMP_Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace SMPServer
{
    internal class MessageServer
    {
        public static event EventHandler<PacketEventArgs> PacketRecieved;

        public static void Start(object o)
        {
            FormSmpServer form = o as FormSmpServer;

            if (form != null)
            {
                IPAddress iPAddress = IPAddress.Parse(form.IpAddress);
                int port = form.Port;

                TcpListener server = new TcpListener(iPAddress, port);

                server.Start();

                while (true)
                {
                    TcpClient connection = server.AcceptTcpClient();

                    ProcessConnection(connection);
                }
            }
        }

        public static void ProcessConnection(TcpClient connection)
        {
            NetworkStream networkStream = connection.GetStream();

            StreamReader networkStreamReader = new StreamReader(networkStream);

            string version = networkStreamReader.ReadLine();

            if (version == Enumerations.SmpVersion.Version_1_0.ToString())
            {
                string messageType = networkStreamReader.ReadLine();
                //Message Producer
                if (messageType == Enumerations.SmpMessageType.PutMessage.ToString())
                {
                    string userID = networkStreamReader.ReadLine();
                    string password = networkStreamReader.ReadLine();
                    string priority = networkStreamReader.ReadLine();
                    string dateTime = networkStreamReader.ReadLine();
                    string message = networkStreamReader.ReadLine();

                    SmpPacket smpPacket = new SmpPacket(version, messageType, userID, password, priority, dateTime, message);

                    ProcessSmpPutPacket(smpPacket);

                    string responsePacket = "Received Packet: " + DateTime.Now + Environment.NewLine;

                    SendSmpResponsePacket(responsePacket, networkStream);

                    networkStreamReader.Close();

                    PacketEventArgs eventArgs = new PacketEventArgs(smpPacket);

                    if (PacketRecieved != null) PacketRecieved(null, eventArgs);
                }
                //Message Consumer
                else if (messageType == Enumerations.SmpMessageType.GetMessage.ToString())
                {
                    string userID = networkStreamReader.ReadLine();
                    string password = networkStreamReader.ReadLine();
                    string priority = networkStreamReader.ReadLine();

                    SmpPacket smpPacket = ProcessSmpGetPacket(userID, password, priority);
                    string responsePacket = "";
                    if (smpPacket == null)
                    {
                        responsePacket = "NO_MESSAGE_FOUND";
                        SendSmpResponsePacket(responsePacket, networkStream);
                        networkStreamReader.Close();
                        return;
                    }

                    string record = smpPacket.DateTime + Environment.NewLine;
                    record += smpPacket.Message + Environment.NewLine;
                    responsePacket = "Message Information: " + Environment.NewLine + record;

                    SendSmpResponsePacket(responsePacket, networkStream);

                    networkStreamReader.Close();

                    PacketEventArgs eventArgs = new PacketEventArgs(smpPacket);



                    if (PacketRecieved != null) PacketRecieved(null, eventArgs);
                }
            }
            else
            {
                string responsePacket = "Unsupported Version: " + version + Environment.NewLine;

                SendSmpResponsePacket(responsePacket, networkStream);

                networkStreamReader.Close();
            }
        }

		private static void ProcessSmpPutPacket(SmpPacket smpPacket)
        {
            try
            {
                if (smpPacket != null)
                {
                    string record = smpPacket.Version + Environment.NewLine;
                    record += smpPacket.UserID + Environment.NewLine;
                    record += smpPacket.Password + Environment.NewLine;
                    record += smpPacket.Priority + Environment.NewLine;
                    record += smpPacket.DateTime + Environment.NewLine;
                    record += smpPacket.Message + Environment.NewLine;

                    StreamWriter writer = new StreamWriter("Messages.txt", true);

                    writer.WriteLine(record);
                    writer.Flush();

                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogExeption(ex);
            }
        }

        private static SmpPacket ProcessSmpGetPacket(string requestorsUserID, string requestorsPassword, string requestedPriority)
        {
            try
            {
                if (!File.Exists("Messages.txt"))
                {
                    return null;
                }
                var lines = File.ReadAllLines("Messages.txt").ToList();
                var remaining = new List<string>();

                SmpPacket foundPacket = null;

                for (int i = 0; i < lines.Count;)
                {
                    // Skip blank lines
                    if (string.IsNullOrWhiteSpace(lines[i]))
                    {
                        i++;
                        continue;
                    }

                    //4 lines for a packet
                    if (i + 5 >= lines.Count)
                        break;

                    string version = lines[i];
                    string userID = lines[i + 1];
                    string password = lines[i + 2];
                    string priority = lines[i + 3];
                    string date = lines[i + 4];
                    string message = lines[i + 5];

                    bool match = (foundPacket == null && priority == requestedPriority && userID == requestorsUserID && password == requestorsPassword);

                    if (match)
                    {
                        // Build packet to return
                        foundPacket = new SmpPacket(version, Enumerations.SmpMessageType.GetMessage.ToString(), userID, password, priority, date, message);
                    }
                    else
                    {
                        // Keep other packets
                        remaining.Add(version);
                        remaining.Add(userID);
                        remaining.Add(password);
                        remaining.Add(priority);
                        remaining.Add(date);
                        remaining.Add(message);
                        remaining.Add("");
                    }

                    i += 6; // move to next packet
                }

                // Rewrite file
                File.WriteAllLines("Messages.txt", remaining);

                return foundPacket;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogExeption(ex);
                return null;
            }
        }



        private static void SendSmpResponsePacket(String responsePacket, NetworkStream dataStream)
        {
            StreamWriter writer = new StreamWriter(dataStream);

            writer.WriteLine(responsePacket);

            writer.Close();
        }
    }
}
