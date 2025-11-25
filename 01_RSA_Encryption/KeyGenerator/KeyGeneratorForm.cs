using CryptographyUtilities;
using System;
using System.IO;
using System.Windows.Forms;

namespace KeyGenerator
{
    public partial class KeyGeneratorForm : Form
    {
        readonly string PublicKeyFile = "Public.key";
        readonly string PrivateKeyFile = "Private.key";
        public KeyGeneratorForm()
        {
            InitializeComponent();
        }

        private void buttonGenerateKeys_Click(object sender, EventArgs e)
        {
            Encryption.GeneratePublicPrivateKeyPair(PublicKeyFile, PrivateKeyFile);

            //Display the public key in the UI
            string publicKeyString = File.ReadAllText(PublicKeyFile);
            textBoxtPublicKey.Text = publicKeyString;

            //Display the private key in the UI
            string privateKeyString = File.ReadAllText(PrivateKeyFile);
            textBoxPrivateKey.Text = privateKeyString;
        }
    }
}
