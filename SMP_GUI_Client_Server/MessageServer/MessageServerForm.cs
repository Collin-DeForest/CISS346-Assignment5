using SMP_Library;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

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

            StreamReader reader = new StreamReader("Messages.txt");

            string version = reader.ReadLine();

            while (version != null)
            {
                string priority = reader.ReadLine();
                string dateTime = reader.ReadLine();
                string message = reader.ReadLine();
                string emptyLine = reader.ReadLine();

                string record = "Version: " + version + Environment.NewLine;
                record += "Priority: " + priority + Environment.NewLine;
                record += "Date/Time: " + dateTime + Environment.NewLine;
                record += "Message: " + message + Environment.NewLine;

                textBoxMessages.AppendText(record + Environment.NewLine);

                version = reader.ReadLine();
            }

            reader.Close();
        }
    }
}
