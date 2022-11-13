using System.Security.Cryptography;
using System.Text;

namespace Encryption.Asymmetric.Algorithms
{
    public class RSACryptoService : IRSACryptoService
    {
        /// <summary>
        /// Uses RSA Algorithm to do asymmetric encryption
        /// </summary>
        /// <param name="publicKeyXML">XML formatted string with RSA public key to encrypt</param>
        /// <param name="dataToDycript">a data string of content to be encrypted</param>
        /// <returns>Returns rsa encrypted string</returns>
        public string Encrypt(string publicKeyXML, string dataToDycript)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKeyXML);
                var temp = rsa.Encrypt(Encoding.UTF8.GetBytes(dataToDycript), false);
                return Convert.ToBase64String(temp);
            }
        }

        /// <summary>
        /// Uses RSA Algorithm to do asymmetric decryption
        /// </summary>
        /// <param name="publicPrivateKeyXML">XML formatted string with RSA public and private keys</param>
        /// <param name="encryptedData">RSA encrypted data string</param>
        /// <returns>A string of decrypted data</returns>
        public string Decrypt(string publicPrivateKeyXML, byte[] encryptedData)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicPrivateKeyXML);
                return Encoding.UTF8.GetString(rsa.Decrypt(encryptedData, false));
            }
        }

        /// <summary>
        /// Used to generate a new key-set  for RSA algorithm, keys are delivered in a pair, in the format of a dictionary
        /// The keys is mapped by Public and Private in key/value pair
        /// </summary>
        /// <returns>Dictionary with RSA keys, public and private</returns>
        public Dictionary<string, string> GenerateNewKeySet()
        {
            Dictionary<string, string> newKeys2 = new Dictionary<string, string>();
            const int PROVIDER_RSA_FULL = 1;
            string CONTAINER_NAME = Guid.NewGuid().ToString();
            CspParameters cspParams;
            cspParams = new CspParameters(PROVIDER_RSA_FULL);
            cspParams.KeyContainerName = CONTAINER_NAME;
            cspParams.Flags = CspProviderFlags.NoFlags;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                //rsa.KeySize = 4096;
                newKeys2.Add("Private", rsa.ToXmlString(true));
                newKeys2.Add("Public", rsa.ToXmlString(false));
                rsa.Clear();                
            }
            return newKeys2;
        }
    }
}
