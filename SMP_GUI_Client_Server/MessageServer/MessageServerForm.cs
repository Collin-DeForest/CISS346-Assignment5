using SMP_Library;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CryptographyUtilities;

namespace SMPServer
{
    public partial class FormSmpServer : Form
    {
        public string IpAddress;
        public int Port;

        public FormSmpServer()
        {
            InitializeComponent();
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                IpAddress = textBoxServerIPAddress.Text;
                Port = int.Parse(textBoxPortNumber.Text);

                MessageServer.PacketRecieved += SMPServer_PacketRecieved;

                ThreadPool.QueueUserWorkItem(MessageServer.Start, this);

                MessageBox.Show("Server started...", "Server Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                buttonStartServer.Enabled = false;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogExeption(ex);
            }
        }

        private void SMPServer_PacketRecieved(object sender, PacketEventArgs eventArgs)
        {
            try
            {
                Invoke(new EventHandler<PacketEventArgs>(SMPPacketReceived), sender, eventArgs);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogExeption(ex);
            }
        }

        private void SMPPacketReceived(object sender, PacketEventArgs eventArgs)
        {
            try
            {
                if (eventArgs != null)
                {
                    string messageType = eventArgs.SmpPacket.MessageType.ToString();
                    string messagePriority = eventArgs.SmpPacket.Priority;
                    string messageUserID = eventArgs.SmpPacket.UserID;
                    string messagePassword = eventArgs.SmpPacket.Password;

                    textBoxUserID.Text = messageUserID;
                    textBoxPassword.Text = messagePassword;
                    textBoxMessageType.Text = messageType;
                    textBoxMessagePriority.Text = messagePriority;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogExeption(ex);
            }
        }

        private void buttonShowMessages_Click(object sender, EventArgs e)
        {
            textBoxMessages.Clear();

            // Determine selected priority
            string filterPriority = null;
            if (radioButtonPriorityLow.Checked) filterPriority = "1";
            else if (radioButtonPriorityMedium.Checked) filterPriority = "2";
            else if (radioButtonPriorityHigh.Checked) filterPriority = "3";
            else if (radioAll.Checked) filterPriority = null; // Show all

            // check if file exists
            string fileName = "Messages.txt";
            if (File.Exists(fileName) == false)
            {
                MessageBox.Show("No messages to display.", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (StreamReader reader = new StreamReader("Messages.txt"))
            {
                while (true)
                {
                    string version = reader.ReadLine();
                    if (version == null) break;

                    string userID = reader.ReadLine();
                    string password = reader.ReadLine();
                    string priority = reader.ReadLine();
                    string dateTime = reader.ReadLine();
                    string message = reader.ReadLine();
                    string empty = reader.ReadLine();

                    string decrypted = Decrypt(message);

                    // Filter by priority and create text
                    if (filterPriority == null || priority == filterPriority)
                    {
                        string record = "Version: " + version + Environment.NewLine;
                        record += "User ID: " + userID + Environment.NewLine;
                        record += "Password: " + password + Environment.NewLine;
                        record += "Priority: " + priority + Environment.NewLine;
                        record += "Date/Time: " + dateTime + Environment.NewLine;
                        record += "Message: " + decrypted + Environment.NewLine;

                        textBoxMessages.AppendText(record + Environment.NewLine);
                    }
                }

                if (textBoxMessages.TextLength == 0)
                {
                    MessageBox.Show("No messages to display for this priority level.", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private string Decrypt(string message)
        {
            try
            {
                string producerKeyFolder = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\MessageProducer\bin\Debug\"));
                string privateKeyPath = Path.Combine(producerKeyFolder, "Private.key");
                if (File.Exists(privateKeyPath))
                {
                    return Encryption.DecryptMessage(message, privateKeyPath);
                }
                else
                {
                    return message;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogExeption(ex);
                return message;
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            Registrations regForm = new Registrations();
            regForm.ShowDialog();
        }
    }
}
