namespace Encryption.Hashing
{
    public class ErrorHashing : IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            return "Incorrect hashing type.";
        }
    }
}
