using Encryption.CaesarCipher.Algorithms;

namespace Encryption.CaesarCipher.Factories
{
    public class CaesarCipherFactoryImplementation : ICaesarCipherFactory
    {
        /// <summary>
        /// Uses factory pattern to create instance used to cipher and decipher Caesar "encryption"
        /// </summary>
        /// <returns>New instance og ICaesarCipherGenerator</returns>
        public ICaesarCipherGenerator Create()
        {
            return new CaesarCipherGenarator();
        }
    }
}
