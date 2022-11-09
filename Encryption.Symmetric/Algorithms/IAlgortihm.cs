using Encryption.Symmetric.Models;
using System.Security.Cryptography;

namespace Encryption.Symmetric.Algorithms
{
    public interface IAlgortihm
    {
        string Encrypt(CyptographicSetup setup);

        string Decrypt(CyptographicSetup setup);
    }
}
