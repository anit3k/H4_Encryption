namespace Encryption.Hashing
{
    public class HashingFactoryImplementation : IHashingFactory
    {
        public IHashing CreateHashing(string hashType)
        {
            var type = GetEnum<HashingType>(hashType);
            switch (type)
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

        private T GetEnum<T>(string hashType)
        {
            return (T)Enum.Parse(typeof(HashingType), hashType, true);
        }
    }
}
