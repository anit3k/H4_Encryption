using System.Security.Cryptography;
using System.Text;

namespace Encryption.Hashing.Algorithms
{
    /// <summary>
    /// Base class for hashing
    /// </summary>
    public abstract class HashingBase
    {
        /// <summary>
        /// This method return the byte array containing hashing
        /// </summary>
        /// <param name="dataToHash">Data to be hashed</param>
        /// <param name="algorithm">Hashing algorithm</param>
        /// <returns></returns>
        protected byte[] GethashingBytes(string dataToHash, HashAlgorithm algorithm)
        {
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));
        }

        /// <summary>
        /// This methods converts the hashing byte array to a string
        /// </summary>
        /// <param name="bytes">Byte array to be hashed</param>
        /// <returns>Hashed string</returns>
        protected string ConvertHashingByteToString(byte[] bytes)
        {
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        protected byte[] GethashingBytesWithSalt(string dataToHash, byte[] salt, HashAlgorithm algorithm)
        {
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(dataToHash).Concat(salt).ToArray());
        }

        protected string ConvertGeneratedKeyToString(byte[] key)
        {
            return Convert.ToBase64String(key);
        }
    }
}
