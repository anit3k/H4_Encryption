using System.Security.Cryptography;
using System.Text;

namespace Encryption.Hashing
{
    public class MD5Hashing : IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            using (MD5 MD5Hash = MD5.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = MD5Hash.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));

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
