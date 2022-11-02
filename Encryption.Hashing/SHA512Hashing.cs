using System.Security.Cryptography;
using System.Text;

namespace Encryption.Hashing
{
    public class SHA512Hashing : HashingBase, IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            using (SHA512 algorithm = SHA512.Create())
            {
                byte[] bytes = base.GethashingBytes(dataToHash, algorithm);
                return base.ConvertToString(bytes);
            }
        }
    }
}
