﻿using System.Security.Cryptography;
using System.Text;

namespace Encryption.Hashing
{
    /// <summary>
    /// Base class for hashing
    /// </summary>
    public class HashingBase
    {
        /// <summary>
        /// This method return the byte array containing hashing
        /// </summary>
        /// <param name="dataToHash">Data to be hashed</param>
        /// <param name="algorithm">Hashing algorithm</param>
        /// <returns></returns>
        internal byte[] GethashingBytes(string dataToHash, HashAlgorithm algorithm)
        {
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));
        }

        /// <summary>
        /// This methods converts the hashing byte array to a string
        /// </summary>
        /// <param name="bytes">Byte array to be hashed</param>
        /// <returns>Hashed string</returns>
        internal string ConvertToString(byte[] bytes)
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
    }
}