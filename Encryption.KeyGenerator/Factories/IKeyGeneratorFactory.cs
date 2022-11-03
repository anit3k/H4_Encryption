using Encryption.KeyGenerator.Generators;

namespace Encryption.KeyGenerator.Factories
{
    public interface IKeyGeneratorFactory
    {
        public IGenerator CreateKeyGenerator();
    }
}
