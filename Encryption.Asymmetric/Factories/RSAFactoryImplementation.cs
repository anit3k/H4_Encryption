using Encryption.Asymmetric.Algorithms;

namespace Encryption.Asymmetric.Factories
{
    public class RSAFactoryImplementation : IRSAFactory
    {
        /// <summary>
        /// Implements the factory pattern to create a new instance of the RSA algorithm
        /// </summary>
        /// <returns>An instance of IRSACryptoService to make asymmetric encryption and decryption</returns>
        public IRSACryptoService Create()
        {
            return new RSACryptoService();
        }
    }
}
