using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace CryptographyUtilities
{
    public class Encryption
    {
        public static string EncryptMessage(string message, string publicKeyFile)
        {
            //Convert the message to an array of bytes
            byte[] messageBytes = Encoding.Unicode.GetBytes(message);

            //Get the RSA public key parameters
            RSAParameters rsaParams = GetRsaParameters(publicKeyFile);

            //Allocate a RSACryptoServiceProvider and import the public key parameters
            RSACryptoServiceProvider cryptoService = new RSACryptoServiceProvider();
            cryptoService.ImportParameters(rsaParams);

            //Encrypt and Decrypt bool Parameter: TRUE: OAEP Padding FALSE: PKCS#1.5 Padding
            byte[] encryptedMessageBytes = cryptoService.Encrypt(messageBytes, false);

            //Save the encrypted message to a file
            string encryptedMessage = Convert.ToBase64String(encryptedMessageBytes);

            return encryptedMessage;
        }
        public static string DecryptMessage(string encryptedMessage, string privateKeyFile)
        {
            byte[] encryptedMessageBytes = Convert.FromBase64String(encryptedMessage);

            //Get the RSA public key parameters
            RSAParameters rsaParams = GetRsaParameters(privateKeyFile);

            //Allocate a RSACryptoServiceProvider and import the private key parameters
            RSACryptoServiceProvider cryptoService = new RSACryptoServiceProvider();
            cryptoService.ImportParameters(rsaParams);

            //Encrypt and Decrypt bool Parameter: TRUE: OAEP Padding FALSE: PKCS#1.5 Padding
            byte[] decryptedMessageBytes = cryptoService.Decrypt(encryptedMessageBytes, false);

            //Convert bytes to string
            string decryptedMessage = Encoding.Unicode.GetString(decryptedMessageBytes);

            return decryptedMessage;
        }
        public static string EncryptMessageToFile(string message, string publicKeyFile, string encryptedMessageFile)
        {
            string encryptedMessage = EncryptMessage(message, publicKeyFile);

            File.WriteAllText(encryptedMessageFile, encryptedMessage);

            return encryptedMessage;
        }
        public static string DecryptMessageFromFile(string encryptedMessageFile, string privateKeyFile)
        {
            string encryptedMessage = File.ReadAllText(encryptedMessageFile);
 
            string decryptedMessage = DecryptMessage(encryptedMessage, privateKeyFile);

            return decryptedMessage;
        }
        private static RSAParameters GetRsaParameters(string keyFile)
        {
            //Read the key from the file
            string keyString = File.ReadAllText(keyFile);

            //Convert the key string to a RSAParameters object
            StringReader stringReader = new StringReader(keyString);
            XmlSerializer serializer = new XmlSerializer(typeof(RSAParameters));
            RSAParameters key = (RSAParameters)serializer.Deserialize(stringReader);

            return key;
        }

        public static void GeneratePublicPrivateKeyPair(string publicKeyFile, string privateKeyFile)
        {
            //RSACryptoServiceProvider: 2048-bit RSA Public/Private Key Pair
            RSACryptoServiceProvider cryptoService = new RSACryptoServiceProvider(2048);

            //Generate the public key
            RSAParameters publicKey = cryptoService.ExportParameters(false);

            //Convert the public key into a string
            StringWriter stringWriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(RSAParameters));
            serializer.Serialize(stringWriter, publicKey);
            string publicKeyString = stringWriter.ToString();

            //Save the public key to a file
            File.WriteAllText(publicKeyFile, publicKeyString);

            //Generate the private key
            RSAParameters privateKey = cryptoService.ExportParameters(true);

            //Convert the private key into a string
            stringWriter = new StringWriter();
            serializer = new XmlSerializer(typeof(RSAParameters));
            serializer.Serialize(stringWriter, privateKey);
            string privateKeyString = stringWriter.ToString();

            //Save the private key to a file
            File.WriteAllText(privateKeyFile, privateKeyString);
        }
    }
}
