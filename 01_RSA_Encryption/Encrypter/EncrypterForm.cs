using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using CryptographyUtilities;

namespace Encrypter
{
    public partial class EncrypterForm : Form
    {
        public EncrypterForm()
        {
            InitializeComponent();
        }

        private void buttonEncryptMessage_Click(object sender, EventArgs e)
        {
            string message = textBoxMessage.Text;
            string publicKeyFile = textBoxPublicKeyFile.Text;
            string encryptedMessageFile = textBoxEncryptedMessageFile.Text;

            string encryptedMessage = Encryption.EncryptMessageToFile(message, publicKeyFile, encryptedMessageFile);

            textBoxtEncryptedMessage.Text = encryptedMessage;
        }
    }
}
