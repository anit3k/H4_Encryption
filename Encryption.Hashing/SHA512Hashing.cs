using System.Security.Cryptography;
using System.Text;

namespace Encryption.Hashing
{
    public class SHA512Hashing : IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            using (SHA512 SHA512Hash = SHA512.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = SHA512Hash.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));

                // Convert byte array to a string   
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
