using Encryption.Asymmetric.Algorithms;

namespace Encryption.Asymmetric.Factories
{
    public class RSAFactoryImplementation : IRSAFactory
    {
        public IRSACryptoService Create()
        {
            return new RSACryptoService();
        }
    }
}
