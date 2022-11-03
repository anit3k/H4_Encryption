namespace Encryption.Hashing.Algorithms
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

        public string[] GetHashValueWithSalt(string dataToHash, byte[] salt)
        {
            var result = new string[2];
            result[0] = "Incorrect hashing type.";
            result[1] = "Incorrect hashing type.";
            return result;
        }
    }
}
