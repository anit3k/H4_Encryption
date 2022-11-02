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

        public string GetHashValueWithSalt(string dataToHash, byte[] salt)
        {
            using (SHA384 algorithm = SHA384.Create())
            {
                byte[] bytes = base.GethashingBytesWithSalt(dataToHash, salt, algorithm);
                return base.ConvertToString(bytes);
            }
        }
    }
}
