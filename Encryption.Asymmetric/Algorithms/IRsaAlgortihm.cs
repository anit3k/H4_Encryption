namespace Encryption.Asymmetric.Algorithms
{
    public interface IRSACryptoService
    {
        public Dictionary<string, string> GenerateNewKeySet();
        public string Encrypt(string publicKeyXML, string dataToDycript);
        public string Decrypt(string publicPrivateKeyXML, byte[] encryptedData);
    }
}
