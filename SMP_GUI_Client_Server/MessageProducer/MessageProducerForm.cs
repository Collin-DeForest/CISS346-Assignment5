using SMP_Library;
using System;
using System.Windows.Forms;

namespace SMPClientProducer
{
    public partial class MessageProducerForm : Form
    {
        public MessageProducerForm()
        {
            InitializeComponent();

            MessageProducer.SMPResponsePacketRecieved += SMPClientProducer_SMPResponsePacketRecieved;
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
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

            string message = textBoxMessageContent.Text;

            //Build the SMP packet
            SmpPacket smpPacket = new SmpPacket(Enumerations.SmpVersion.Version_1_0.ToString(),
                Enumerations.SmpMessageType.PutMessage.ToString(), priority.ToString(), DateTime.Now.ToString(),
                message);

            //Send the packet
            MessageProducer.SendSmpPacket(textBoxServerIPAddress.Text,
                int.Parse(textBoxApplicationPortNumber.Text), smpPacket);

            MessageBox.Show("Message sent...", "Message Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SMPClientProducer_SMPResponsePacketRecieved(object sender, SMPResponsePacketEventArgs e)
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
                textBoxServerResponse.Text = eventArgs.ResponseMessage;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogExeption(ex);
            }
        }
    }
}
