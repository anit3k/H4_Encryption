namespace Encryption.Hashing.Algorithms
{
    /// <summary>
    /// Interface to implement on each algorithm get the hash value
    /// </summary>
    public interface IHashing
    {
        /// <summary>
        /// Convert a string to "simple" hash value
        /// </summary>
        /// <param name="dataToHash">data to be hashed</param>
        /// <returns>Hashvalue in string format</returns>
        string GetHashValue(string dataToHash);

        /// <summary>
        /// The next level of hashing, hashing with salt, this method concatenate the data with a salt, and then hashes the string
        /// </summary>
        /// <param name="dataToHash">string of data to be hashed</param>
        /// <param name="salt">the salt string value, should be made by a random number generator</param>
        /// <returns>Hashvalue in string format</returns>
        string[] GetHashValueWithSalt(string dataToHash, string salt);

        /// <summary>
        /// The highest level of hashing, using HMAC algorithm to hash a value using a key, the method could be
        /// combination with a salt, to make it extra crispy
        /// </summary>
        /// <param name="dataToHash">string of data to be hashed</param>
        /// <param name="key">string value key created with random number generator</param>
        /// <returns>Hashvalue in string format</returns>
        string[] GetHashValueWithKey(string dataToHash, string key);
    }
}
