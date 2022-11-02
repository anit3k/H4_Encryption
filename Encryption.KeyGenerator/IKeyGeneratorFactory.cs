namespace Encryption.KeyGenerator
{
    public interface IKeyGeneratorFactory
    {
        public IGenerator CreateKeyGenerator();
    }
}
