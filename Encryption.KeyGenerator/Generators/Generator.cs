using System.Security.Cryptography;

namespace Encryption.KeyGenerator.Generators
{
    public class Generator : IGenerator
    {
        /// <summary>
        /// Generates a random key define by byte size
        /// </summary>
        /// <param name="KeySize">size of key in bytes</param>
        /// <returns>string with generated key</returns>
        public string GenerateKey(int KeySize)
        {
            var randomNumber = new byte[KeySize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }
    }
}
