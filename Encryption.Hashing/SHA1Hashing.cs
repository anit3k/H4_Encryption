using System.Security.Cryptography;
using System.Text;

namespace Encryption.Hashing
{
    public class SHA1Hashing : HashingBase, IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            using (SHA1 algorithm = SHA1.Create())
            {
                byte[] bytes = base.GethashingBytes(dataToHash, algorithm);
                return base.ConvertToString(bytes);
            }
        }
    }
}
