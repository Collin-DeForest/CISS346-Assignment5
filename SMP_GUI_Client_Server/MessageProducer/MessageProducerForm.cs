using System;
using SMP_Library;
using System.IO;
using System.Windows.Forms;
using CryptographyUtilities;

namespace SMPClientProducer
{
	public partial class MessageProducerForm : Form
	{
		public MessageProducerForm()
		{
			InitializeComponent();

			MessageProducer.SMPResponsePacketRecieved += SMPClientProducer_SMPResponsePacketRecieved;

			GenerateKeys();
		}

		private void GenerateKeys()
		{
			string publicKey = "Public.key";
			string privateKey = "Private.key";
			if (!File.Exists(publicKey) || !File.Exists(privateKey))
			{
				try
				{
					Encryption.GeneratePublicPrivateKeyPair(publicKey, privateKey);
				}
				catch (Exception ex)
				{
					ExceptionLogger.LogExeption(ex);
				}
			}
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
			string userID = userIDButton.Text;
			string password = passwordButton.Text;

			string message = textBoxMessageContent.Text;

			//Build the SMP packet
			SmpPacket smpPacket = new SmpPacket(Enumerations.SmpVersion.Version_1_0.ToString(),
				Enumerations.SmpMessageType.PutMessage.ToString(), userID, password, priority.ToString(), DateTime.Now.ToString(),
				message);

			//Send the packet
			MessageProducer.SendSmpPacket(textBoxServerIPAddress.Text,
				int.Parse(textBoxApplicationPortNumber.Text), smpPacket, "Public.key");

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
				if (eventArgs.ResponseMessage == "CONNECTION_ERROR")
				{
					MessageBox.Show("Server is Offline", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Message sent...", "Message Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
					textBoxServerResponse.Text = eventArgs.ResponseMessage;
				}
			}
			catch (Exception ex)
			{
				ExceptionLogger.LogExeption(ex);
			}
		}
	}
}
