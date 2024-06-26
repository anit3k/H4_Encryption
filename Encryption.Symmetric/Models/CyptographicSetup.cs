﻿using Encryption.Symmetric.Enums;
using System.Security.Cryptography;

namespace Encryption.Symmetric.Models
{
    /// <summary>
    /// This "model" is used to setup symmetric algorithm with CipherMode, Padding, keys and message/string
    /// to be encrypted/decrypted. This class also contains internal methods to ensure correct conversion of 
    /// base64 strings in the encrypt/decrypt algorithm methods.
    /// </summary>
    public class CyptographicSetup
    {
        public CyptographicSetup()
        {
        }       

        public string Message { get; set; }
        public string IV { get; set; }
        public string Key { get; set; }
        public CipherMode CipherMode { get; set; }
        public PaddingMode PaddingMode { get; set; }
        public SymmetricType Type { get; set; }

        internal byte[] GetIVInBytes()
        {
            return Convert.FromBase64String(IV);
        }
        internal byte[] GetKeyInBytes()
        {
            return Convert.FromBase64String(Key);
        }
        internal byte[] GetMessageInBytes()
        {
            return Convert.FromBase64String(Message);
        }
        private T GetSymmetricType<T>(string algorithm)
        {
            return (T)Enum.Parse(typeof(SymmetricType), algorithm, true);
        }
    }
}
