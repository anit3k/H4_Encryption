using System.Security.Cryptography;

namespace Encryption.Hashing
{
    public class SHA384Hashing : HashingBase, IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            using (SHA384 algorithm = SHA384.Create())
            {
                byte[] bytes = base.GethashingBytes(dataToHash, algorithm);
                return base.ConvertToString(bytes);
            }
        }
    }
}
