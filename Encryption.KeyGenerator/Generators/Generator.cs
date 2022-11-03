using System.Security.Cryptography;

namespace Encryption.KeyGenerator.Generators
{
    public class Generator : IGenerator
    {
        public byte[] GenerateKey(int KeySize)
        {
            var randomNumber = new byte[KeySize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            return randomNumber;
        }
    }
}
