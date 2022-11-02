using System.Security.Cryptography;
using System.Text;

namespace Encryption.Hashing
{
    public class MD5Hashing : HashingBase, IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            using (MD5 algorithm = MD5.Create())
            {
                byte[] bytes = base.GethashingBytes(dataToHash, algorithm);
                return base.ConvertToString(bytes);
            }
        }
    }
}
