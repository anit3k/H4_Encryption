using Encryption.Hashing.Algorithms;
using Encryption.Hashing.Enums;

namespace Encryption.Hashing.Factories
{
    /// <summary>
    /// Used to create Algorithm class, also part of seperating domain logic from UI application
    /// </summary>
    public class HashingFactoryImplementation : IHashingFactory
    {
        /// <summary>
        /// Creates a new instance of a algorithm
        /// </summary>
        /// <param name="hashType">Name of alforithm</param>
        /// <returns></returns>
        public IHashing CreateHashing(string hashType)
        {
            switch (GetEnum<HashingType>(hashType))
            {
                case HashingType.SHA1:
                    return new SHA1Hashing();
                case HashingType.SHA256:
                    return new SHA256Hashing();
                case HashingType.SHA384:
                    return new SHA384Hashing();
                case HashingType.SHA512:
                    return new SHA512Hashing();
                case HashingType.MD5:
                    return new MD5Hashing();
                default:
                    return new ErrorHashing();
            }
        }

        /// <summary>
        /// Get the corresponding enum for hashing type
        /// </summary>
        /// <typeparam name="T">Generic</typeparam>
        /// <param name="hashType">string that correspond to enum</param>
        /// <returns>hashing type enum</returns>
        private T GetEnum<T>(string hashType)
        {
            return (T)Enum.Parse(typeof(HashingType), hashType, true);
        }
    }
}
