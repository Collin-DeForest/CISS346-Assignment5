using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using CryptographyUtilities;

namespace Decrypter
{
    public partial class DecrypterForm : Form
    {
        public DecrypterForm()
        {
            InitializeComponent();
        }

        private void buttonDecryptMessage_Click(object sender, EventArgs e)
        {
            //Read the encrypted message from a file
            string encryptedMessageFile = textBoxMessageFile.Text;
            string privateKeyFile = textBoxPrivateKeyFile.Text;

            string decryptedMessage = Encryption.DecryptMessageFromFile(encryptedMessageFile, privateKeyFile);

            textBoxtDecryptedMessage.Text = decryptedMessage;
        }
    }
}
