﻿using System.Security.Cryptography;

namespace Encryption.Hashing
{
    public class SHA256Hashing : HashingBase, IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            using (SHA256 algorithm = SHA256.Create())
            { 
                byte[] bytes = base.GethashingBytes(dataToHash, algorithm);  
                return base.ConvertToString(bytes);
            }
        }      
    }
}