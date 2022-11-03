using Encryption.KeyGenerator.Generators;

namespace Encryption.KeyGenerator.Factories
{
    public class KeyGeneratorFactoryImplementation : IKeyGeneratorFactory
    {
        public IGenerator CreateKeyGenerator()
        {
            return new Generator();
        }
    }
}
