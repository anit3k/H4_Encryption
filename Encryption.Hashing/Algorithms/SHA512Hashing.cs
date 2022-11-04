using System.Security.Cryptography;
using System.Text;

namespace Encryption.Hashing.Algorithms
{
    public class SHA512Hashing : HashingBase, IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            using (SHA512 algorithm = SHA512.Create())
            {
                byte[] bytes = GethashingBytes(dataToHash, algorithm);
                return ConvertHashingByteToString(bytes);
            }
        }

        public string[] GetHashValueWithSalt(string dataToHash, string salt)
        {
            string[] result = new string[2];
            result[0] = salt;
            using (SHA512 algorithm = SHA512.Create())
            {
                byte[] bytes = GethashingBytes(String.Concat(dataToHash, salt), algorithm);
                result[1] = ConvertHashingByteToString(bytes);
            }
            return result;
        }

        public string[] GetHashValueWithKey(string dataToHash, string key)
        {
            string[] result = new string[2];
            result[0] = key;
            using (var hash = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                var bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));
                result[1] = ConvertHashingByteToString(bytes);
            }

            return result;
        }
    }
}
