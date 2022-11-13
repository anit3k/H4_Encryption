using Encryption.KeyGenerator.Generators;

namespace Encryption.KeyGenerator.Factories
{
    /// <summary>
    /// Returns a instance of IGenerator used for generating random string
    /// </summary>
    public interface IKeyGeneratorFactory
    {
        public IGenerator CreateKeyGenerator();
    }
}
