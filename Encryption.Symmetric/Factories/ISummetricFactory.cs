using Encryption.Symmetric.Algorithms;

namespace Encryption.Symmetric.Factories
{
    public interface ISymmetricFactory
    {
        IAlgortihm CreateAlgortihm(string algorithm);
    }
}
