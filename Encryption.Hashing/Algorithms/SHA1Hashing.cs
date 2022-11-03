﻿using System.Security.Cryptography;
using System.Text;

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

        public string[] GetHashValueWithKey(string dataToHash, byte[] key)
        {
            string[] result = new string[2];
            result[0] = ConvertGeneratedKeyToString(key);
            using (var hash = new HMACSHA1(key))
            {
                var bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));
                result[1] = ConvertHashingByteToString(bytes);
            }

            return result;
        }
    }
}
