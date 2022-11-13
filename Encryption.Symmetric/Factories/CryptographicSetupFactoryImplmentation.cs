using Encryption.Symmetric.Models;

namespace Encryption.Symmetric.Factories
{
    public class CryptographicSetupFactoryImplmentation : ICryptographicSetupFactory
    {
        public CyptographicSetup Create()
        {
            return new CyptographicSetup();
        }
    }
}
