namespace Encryption.Hashing
{
    /// <summary>
    /// Interface used as access point of other applications, this is the only thing other applications should
    /// know about in this hashing library, properly used as dependency injection.
    /// </summary>
    public interface IHashingFactory
    {
        IHashing CreateHashing(string hashType);
    }
}
