using Encryption.Symmetric.Models;

namespace Encryption.Symmetric.Factories
{
    public interface ICryptographicSetupFactory
    {
        CyptographicSetup Create();
    }
}
