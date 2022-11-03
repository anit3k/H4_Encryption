namespace Encryption.KeyGenerator.Generators
{
    public interface IGenerator
    {
        public byte[] GenerateKey(int KeySize);
    }
}
