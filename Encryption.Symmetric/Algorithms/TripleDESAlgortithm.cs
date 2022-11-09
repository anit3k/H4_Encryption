using Encryption.Symmetric.Models;
using System.Security.Cryptography;

namespace Encryption.Symmetric.Algorithms
{
    public class TripleDESAlgortithm : IAlgortihm
    {
        public string Decrypt(CyptographicSetup setup)
        {
            using (var decrypter = TripleDES.Create())
            {
                decrypter.Mode = setup.CipherMode;
                decrypter.Padding = setup.PaddingMode;
                decrypter.BlockSize = 64;
                decrypter.IV = setup.GetIVInBytes();
                decrypter.Key = setup.GetKeyInBytes();

                using (var memoryStream = new MemoryStream(setup.GetMessageInBytes()))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decrypter.CreateDecryptor(),
                        CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(cryptoStream))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }

                }
            }
        }

        public string Encrypt(CyptographicSetup setup)
        {
            using (var encrypter = TripleDES.Create())
            {
                encrypter.Mode = setup.CipherMode;
                encrypter.Padding = setup.PaddingMode;
                encrypter.BlockSize = 64;
                encrypter.IV = setup.GetIVInBytes();
                encrypter.Key = setup.GetKeyInBytes();

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encrypter.CreateEncryptor(),
                        CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(cryptoStream))
                        {
                            swEncrypt.Write(setup.Message);
                        }
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }
    }
}
