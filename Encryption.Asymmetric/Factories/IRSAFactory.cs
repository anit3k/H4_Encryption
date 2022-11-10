using Encryption.Asymmetric.Algorithms;

namespace Encryption.Asymmetric.Factories
{
    public interface IRSAFactory
    {
        IRSACryptoService Create();
    }
}
