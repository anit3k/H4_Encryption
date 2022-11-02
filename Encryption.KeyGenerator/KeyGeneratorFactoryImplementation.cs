namespace Encryption.KeyGenerator
{
    public class KeyGeneratorFactoryImplementation : IKeyGeneratorFactory
    {
        public IGenerator CreateKeyGenerator()
        {
            return new Generator();
        }
    }
}
