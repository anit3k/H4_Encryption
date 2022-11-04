namespace Encryption.KeyGenerator.Generators
{
    public interface IGenerator
    {
        public string GenerateKey(int KeySize);
    }
}
