using Encryption.Symmetric.Algorithms;
using Encryption.Symmetric.Enums;

namespace Encryption.Symmetric.Factories
{
    public class SymmetricFactoryImplementation : ISymmetricFactory
    {
        public IAlgortihm CreateAlgortihm(string algorithm)
        {
            switch (GetSymmetricType<SymmetricType>(algorithm))
            {
                case SymmetricType.TripleDES:
                    return new TripleDESAlgortithm();
                case SymmetricType.AES:
                    return new AESAlgorithm();
                    default:
                    return new AESAlgorithm();
            }
        }

        private T GetSymmetricType<T>(string algorithm)
        {
            return (T)Enum.Parse(typeof(SymmetricType), algorithm, true);
        }
    }
}
