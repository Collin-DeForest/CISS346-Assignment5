using SMP_Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using CryptographyUtilities;
using System.Windows.Forms;

namespace SMPServer
{
    internal class MessageServer
    {
        private static string publicKeyPath = "ServerPublic.key";
        private static string privateKeyPath = "ServerPrivate.key";
        private static string messagesPath = "Messages.txt";
        private static string registeredClientsPath = "RegisteredClients.txt";

        public static event EventHandler<PacketEventArgs> PacketRecieved;

        private static void createKeys()
        {
            

            // If both exist, do nothing
            if (File.Exists(publicKeyPath) && File.Exists(privateKeyPath))
                return;

            // Otherwise generate a new pair
            try
            {
                Encryption.GeneratePublicPrivateKeyPair(publicKeyPath, privateKeyPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating keypair: " + ex.Message);
            }
        }


        public static void Start(object o)
        {
            FormSmpServer form = o as FormSmpServer;

            if (form != null)
            {

                createKeys();

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

            if (version == Enumerations.SmpVersion.Version_2_0.ToString())
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

                    string responsePacket = "";
                    if (!validateUserCredentials(userID, password))
                    {
                        responsePacket = "AUTHENTICATION_ERROR";
                        SendSmpResponsePacket(responsePacket, networkStream);
                        networkStreamReader.Close();
                        return;
                    }

                    SmpPacket smpPacket = new SmpPacket(version, messageType, userID, password, priority, dateTime, message);

                    ProcessSmpPutPacket(smpPacket);

                    responsePacket = "Received Packet: " + DateTime.Now + Environment.NewLine;

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
                    string responsePacket = "";
                    if (!validateUserCredentials(userID, password))
                    {
                        responsePacket = "AUTHENTICATION_ERROR";
                        SendSmpResponsePacket(responsePacket, networkStream);
                        networkStreamReader.Close();
                        return;
                    }

                    SmpPacket smpPacket = ProcessSmpGetPacket(userID, password, priority);
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
                else if(messageType == Enumerations.SmpMessageType.RegisterClient.ToString())
                {
                    string userID = Encryption.DecryptMessage(networkStreamReader.ReadLine(), "ServerPrivate.key");
                    //string password = Encryption.DecryptMessage(networkStreamReader.ReadLine(), "ServerPrivate.key");
                    string password = networkStreamReader.ReadLine();
                    // Registration logic
                    try
                    {

                        using (StreamWriter writer = new StreamWriter(registeredClientsPath, append: true))
                        {
                            writer.WriteLine($"User ID: {userID}");
                            writer.WriteLine($"Password: {password}");
                            writer.WriteLine(); // blank line to separate entries
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error saving client credentials: " + ex.Message);
                    }

                    string responsePacket = "Registered Client";
                    SendSmpResponsePacket(responsePacket, networkStream);

                    networkStreamReader.Close();
                }
            }
            else
            {
                string responsePacket = "Unsupported Version: " + version + Environment.NewLine;

                SendSmpResponsePacket(responsePacket, networkStream);

                networkStreamReader.Close();
            }
        }

        private static bool validateUserCredentials(string userID, string password)
        {
            // Check that the user is registered.

            // Read from RegisteredClients.txt
            try
            {
                if (!File.Exists(registeredClientsPath))
                {
                    return false;
                }
                string[] lines = File.ReadAllLines(registeredClientsPath);

                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string lineUser = lines[i].Trim();
                    string linePass = lines[i + 1].Trim();

                    // Skip any accidental empty lines
                    if (string.IsNullOrWhiteSpace(lineUser) || string.IsNullOrWhiteSpace(linePass))
                        continue;

                    if (!lineUser.StartsWith("User ID:") || !linePass.StartsWith("Password:"))
                        continue;

                    string registeredUser = lineUser.Substring("User ID:".Length).Trim();
                    string registeredPswd = linePass.Substring("Password:".Length).Trim();
                    string decryptedPassword = Encryption.DecryptMessage(registeredPswd, privateKeyPath);

                    if (registeredUser == userID && decryptedPassword == password)
                        return true;
                    
                    i++; // Move to next pair

                }
                return false;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogExeption(ex);
                return false;
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

                    StreamWriter writer = new StreamWriter(messagesPath, true);

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
                if (!File.Exists(messagesPath))
                {
                    return null;
                }
                var lines = File.ReadAllLines(messagesPath).ToList();
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
                File.WriteAllLines(messagesPath, remaining);

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
