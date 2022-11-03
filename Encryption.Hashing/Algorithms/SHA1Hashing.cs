using System.Security.Cryptography;

namespace Encryption.Hashing.Algorithms
{
    public class SHA1Hashing : HashingBase, IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            using (SHA1 algorithm = SHA1.Create())
            {
                byte[] bytes = GethashingBytes(dataToHash, algorithm);
                return ConvertHashingByteToString(bytes);
            }
        }

        public string[] GetHashValueWithSalt(string dataToHash, byte[] salt)
        {
            string[] result = new string[2];
            result[0] = ConvertGeneratedKeyToString(salt);
            using (SHA1 algorithm = SHA1.Create())
            {
                byte[] bytes = GethashingBytesWithSalt(dataToHash, salt, algorithm);
                result[1] = ConvertHashingByteToString(bytes);
            }
            return result;
        }
    }
}
