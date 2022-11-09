using Encryption.Symmetric.Models;

namespace Encryption.Symmetric.Factories
{
    public class CyptographicSetupFactoryImplmentation : ICyptographicSetupFactory
    {
        public CyptographicSetup Create()
        {
            return new CyptographicSetup();
        }
    }
}
