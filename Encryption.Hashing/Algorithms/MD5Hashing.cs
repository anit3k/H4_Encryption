using System.Security.Cryptography;

namespace Encryption.Hashing.Algorithms
{
    public class MD5Hashing : HashingBase, IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            using (MD5 algorithm = MD5.Create())
            {
                byte[] bytes = GethashingBytes(dataToHash, algorithm);
                return ConvertHashingByteToString(bytes);
            }
        }

        public string[] GetHashValueWithSalt(string dataToHash, byte[] salt)
        {
            string[] result = new string[2];
            result[0] = ConvertGeneratedKeyToString(salt);
            using (MD5 algorithm = MD5.Create())
            {
                byte[] bytes = GethashingBytesWithSalt(dataToHash, salt, algorithm);
                result[1] = ConvertHashingByteToString(bytes);
            }
            return result;
        }
    }
}
