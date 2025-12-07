using System;
using System.IO;
using System.Windows.Forms;
using CryptographyUtilities;
using SMP_Library;

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
			SmpPacket smpPacket = new SmpPacket(Enumerations.SmpVersion.Version_2_0.ToString(),
				Enumerations.SmpMessageType.GetMessage.ToString(), userID, password, priority.ToString(), null, null);


			// we only produce the keys in the producer
			string producerKeyFolder = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\MessageProducer\bin\Debug\"));
			string privateKeyPath = Path.Combine(producerKeyFolder, "Private.key");


			//Send the packet
			MessageConsumer.SendSmpPacket(textBoxServerIPAddress.Text,
				int.Parse(textBoxApplicationPortNumber.Text), smpPacket, privateKeyPath);

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
				if (eventArgs.ResponseMessage == "NO_MESSAGE_FOUND")
				{
					string priority;

					//Get the message priority
					if (radioButtonPriorityLow.Checked == true)
					{
						priority = "low";
					}
					else if (radioButtonPriorityMedium.Checked == true)
					{
						priority = "Medium";
					}
					else
					{
						priority = "High";
					}

					MessageBox.Show("No Priority " + priority + " Messages Available", "Message Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
					textBoxMessageContent.Text = "";

				}
				else if (eventArgs.ResponseMessage == "CONNECTION_ERROR")
				{
					MessageBox.Show("Server is Offline", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					textBoxMessageContent.Text = "";
				}
                else if (eventArgs.ResponseMessage == "AUTHENTICATION_ERROR")
                {
                    MessageBox.Show("Authentication Error: Invalid UserID or Password", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
				{
					// No issues, display the message
					MessageBox.Show("Message retrieved...", "Message Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
					textBoxMessageContent.Text = eventArgs.ResponseMessage;
				}
			}
			catch (Exception ex)
			{
				ExceptionLogger.LogExeption(ex);
			}
		}
	}
}
