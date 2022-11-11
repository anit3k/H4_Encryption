using System.Security.Cryptography;
using System.Text;

namespace Encryption.Asymmetric.Algorithms
{
    public class RSACryptoService : IRSACryptoService
    {
        public string Encrypt(string publicKeyXML, string dataToDycript)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKeyXML);
                var temp = rsa.Encrypt(Encoding.UTF8.GetBytes(dataToDycript), false);
                return Convert.ToBase64String(temp);
            }
        }

        public string Decrypt(string publicPrivateKeyXML, byte[] encryptedData)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicPrivateKeyXML);
                return Encoding.UTF8.GetString(rsa.Decrypt(encryptedData, false));
            }
        }
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
