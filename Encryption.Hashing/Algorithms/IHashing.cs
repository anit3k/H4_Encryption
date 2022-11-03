namespace Encryption.Hashing.Algorithms
{
    /// <summary>
    /// Interface to implement on each algorithm get the hash value
    /// </summary>
    public interface IHashing
    {
        string GetHashValue(string dataToHash);
        string[] GetHashValueWithSalt(string dataToHash, byte[] salt);
        string[] GetHashValueWithKey(string dataToHash, byte[] key);
    }
}
