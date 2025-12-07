using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptographyUtilities;


namespace SMPServer
{
    public partial class Registrations : Form
    {
        private readonly string filePath = "RegisteredClients.txt";
        private readonly string privateKeyPath = "ServerPrivate.key";
        public Registrations()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxRegistrations.Clear();

            if (!File.Exists(filePath))
            {
                textBoxRegistrations.Text = "No registrations found.";
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length - 1; i++)
            {
                string lineUser = lines[i].Trim();
                string linePass = lines[i + 1].Trim();

                // Skip any accidental empty lines
                if (string.IsNullOrWhiteSpace(lineUser) || string.IsNullOrWhiteSpace(linePass))
                    continue;

                if (!lineUser.StartsWith("User ID:") || !linePass.StartsWith("Password:"))
                    continue;

                string userID = lineUser.Substring("User ID:".Length).Trim();
                string password = linePass.Substring("Password:".Length).Trim();

                if (radioButtonUserID.Checked)
                {
                    textBoxRegistrations.AppendText("User ID: " + userID + Environment.NewLine);
                }
                else if (radioButtonUserIDPass.Checked)
                {
                    string decryptedPassword;

                    try
                    {
                        decryptedPassword = Encryption.DecryptMessage(password, privateKeyPath);
                    }
                    catch
                    {
                        decryptedPassword = "[ERROR DECODING]";
                    }

                    textBoxRegistrations.AppendText(
                        $"User ID: {userID}{Environment.NewLine}" +
                        $"Password: {decryptedPassword}{Environment.NewLine}{Environment.NewLine}"
                    );
                }

                i += 2;
            }
        }
    }
}

