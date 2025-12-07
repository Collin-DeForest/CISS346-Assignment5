using CryptographyUtilities;
using SMP_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SMPClientProducer
{
    public partial class ClientRegistrationForm : Form
    {
        public ClientRegistrationForm()
        {
            InitializeComponent();
        }

        public static string SendRegisterPacket(string serverIP, int port, SmpPacket packet)
        {
            using (TcpClient client = new TcpClient())
            {
                client.Connect(serverIP, port);

                using (NetworkStream stream = client.GetStream())
                using (StreamWriter writer = new StreamWriter(stream))
                using (StreamReader reader = new StreamReader(stream))
                {
                    writer.AutoFlush = true;

                    writer.WriteLine(packet.Version);
                    writer.WriteLine(packet.MessageType);
                    writer.WriteLine(packet.UserID);
                    writer.WriteLine(packet.Password);

                    string response = reader.ReadLine();
                    return response;
                }
            }
        }


        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBoxRegistrationID.Text == "" || textBoxRegistrationPassword.Text == "")
            {
                MessageBox.Show("Error: UserID and Password cannot be empty.");
                return;
            }
            string userID = Encryption.EncryptMessage(textBoxRegistrationID.Text, "ServerPublic.key");
            string password = Encryption.EncryptMessage(textBoxRegistrationPassword.Text, "ServerPublic.key");

            SmpPacket smpPacket = new SmpPacket(
                Enumerations.SmpVersion.Version_2_0.ToString(),
                Enumerations.SmpMessageType.RegisterClient.ToString(),
                userID, password
            );
            string response = "";
            try
            {
                response = SendRegisterPacket(
                    textBoxServerIPRegistration.Text,
                    int.Parse(textBoxRegistrationPortNumber.Text),
                    smpPacket
                );
            }
            catch (Exception ex)
            {
                response = "Error: Server is inactive.";
            }
            MessageBox.Show(response);
            this.Close();
        }
    }
}
