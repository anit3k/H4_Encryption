namespace Encryption.Hashing
{
    /// <summary>
    /// This class is used as an error class in the case of wrong hashing type input
    /// </summary>
    public class ErrorHashing : IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            return "Incorrect hashing type.";
        }

        public string GetHashValueWithSalt(string dataToHash, byte[] salt)
        {
            return "Incorrect hashing type.";
        }
    }
}
