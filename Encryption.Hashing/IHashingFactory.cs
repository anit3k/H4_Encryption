namespace Encryption.Hashing
{
    public interface IHashingFactory
    {
        IHashing CreateHashing(string hashType);
    }
}
