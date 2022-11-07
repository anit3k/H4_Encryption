using Encryption.CaesarCipher.Algorithms;

namespace Encryption.CaesarCipher.Factories
{
    public class CaesarCipherFactoryImplementation : ICaesarCipherFactory
    {
        public ICaesarCipherGenerator Create()
        {
            return new CaesarCipherGenarator();
        }
    }
}
