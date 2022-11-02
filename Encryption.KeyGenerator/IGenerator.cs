namespace Encryption.KeyGenerator
{
    public interface IGenerator
    {
        public byte[] GenerateKey(int KeySize);
    }
}
