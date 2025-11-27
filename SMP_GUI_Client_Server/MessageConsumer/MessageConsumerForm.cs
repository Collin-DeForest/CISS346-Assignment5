using SMP_Library;
using System;
using System.Windows.Forms;

namespace SMPClientConsumer
{
    public partial class MessageConsumerForm : Form
    {
        public MessageConsumerForm()
        {
            InitializeComponent();

            MessageConsumer.SMPResponsePacketRecieved += SMPClientConsumer_SMPResponsePacketRecieved;
        }

        private void buttonGetMessage_Click(object sender, EventArgs e)
        {
            int priority;

            //Get the message priority
            if (radioButtonPriorityLow.Checked == true)
            {
                priority = 1;
            }
            else if (radioButtonPriorityMedium.Checked == true)
            {
                priority = 2;
            }
            else
            {
                priority = 3;
            }
            string userID = textBoxUserID.Text;
            string password = textBoxPassword.Text;

            //Build the SMP packet
            SmpPacket smpPacket = new SmpPacket(Enumerations.SmpVersion.Version_1_0.ToString(),
                Enumerations.SmpMessageType.GetMessage.ToString(), userID, password, priority.ToString(), null, null);

            //Send the packet
            MessageConsumer.SendSmpPacket(textBoxServerIPAddress.Text, 
                int.Parse(textBoxApplicationPortNumber.Text), smpPacket);

            MessageBox.Show("Message retrieved...", "Message Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SMPClientConsumer_SMPResponsePacketRecieved(object sender, SMPResponsePacketEventArgs e)
        {
            try
            {
                Invoke(new EventHandler<SMPResponsePacketEventArgs>(SMPResponsePacketRecieved), sender, e);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogExeption(ex);
            }
        }
        private void SMPResponsePacketRecieved(object sender, SMPResponsePacketEventArgs eventArgs)
        {
            try
            {
                textBoxMessageContent.Text = eventArgs.ResponseMessage;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogExeption(ex);
            }
        }
    }
}
