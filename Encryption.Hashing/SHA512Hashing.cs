using System.Security.Cryptography;

namespace Encryption.Hashing
{
    public class SHA512Hashing : HashingBase, IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            using (SHA512 algorithm = SHA512.Create())
            {
                byte[] bytes = base.GethashingBytes(dataToHash, algorithm);
                return base.ConvertHashingByteToString(bytes);
            }
        }

        public string[] GetHashValueWithSalt(string dataToHash, byte[] salt)
        {
            string[] result = new string[2];
            result[0] = base.ConvertGeneratedKeyToString(salt);
            using (SHA512 algorithm = SHA512.Create())
            {
                byte[] bytes = base.GethashingBytesWithSalt(dataToHash, salt, algorithm);
                result[1] = base.ConvertHashingByteToString(bytes);
            }
            return result;
        }
    }
}
