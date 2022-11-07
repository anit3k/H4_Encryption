namespace Encryption.CaesarCipher.Algorithms
{
    public interface ICaesarCipherGenerator
    {
        string CipherText(string data, int shiftIndex, bool isDecrypt);
    }
}
