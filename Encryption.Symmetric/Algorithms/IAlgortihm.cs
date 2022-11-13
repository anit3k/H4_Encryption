using Encryption.Symmetric.Models;
using System.Security.Cryptography;

namespace Encryption.Symmetric.Algorithms
{
    public interface IAlgortihm
    {
        /// <summary>
        /// Encrypts in symmetric algorithm
        /// </summary>
        /// <param name="setup">Model with desired chipermode, padding, keys, and message to decrypt</param>
        /// <returns>encrypted string</returns>
        string Encrypt(CyptographicSetup setup);

        /// <summary>
        /// Decrypts in symmetric algorithm
        /// </summary>
        /// <param name="setup">Model with desired chipermode, padding, keys, and message to decrypt</param>
        /// <returns>decrypted string</returns>
        string Decrypt(CyptographicSetup setup);
    }
}
