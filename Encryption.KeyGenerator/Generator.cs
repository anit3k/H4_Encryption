using System.Security.Cryptography;

namespace Encryption.KeyGenerator
{
    public class Generator : IGenerator
    {
        public byte[] GenerateKey(int KeySize)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[KeySize];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
    }
}
