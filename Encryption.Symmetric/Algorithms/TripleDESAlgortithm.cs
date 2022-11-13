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

        //public string DefaultDecrypt(string toDecrypt, byte[] iv, byte[] key)
        //{
        //    string result = null;
        //    using (var decrypter = TripleDES.Create())
        //    {
        //        decrypter.Mode = CipherMode.CBC;
        //        decrypter.Padding = PaddingMode.PKCS7;
        //        decrypter.BlockSize = 64;
        //        decrypter.IV = iv;
        //        decrypter.Key = key;

        //        using (var memoryStream = new MemoryStream(Convert.FromBase64String(toDecrypt)))
        //        {
        //            using (var cryptoStream = new CryptoStream(memoryStream, decrypter.CreateDecryptor(),
        //                CryptoStreamMode.Read))
        //            {
        //                using (StreamReader srDecrypt = new StreamReader(cryptoStream))
        //                {
        //                    result = srDecrypt.ReadToEnd();
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}

        //public byte[] DefaultEncrypt(string toEncrypt, byte[] iv, byte[] key)
        //{
        //    byte[] result = null;
        //    using (var encrypter = TripleDES.Create())
        //    {
        //        encrypter.Mode = CipherMode.CBC;
        //        encrypter.Padding = PaddingMode.PKCS7;
        //        encrypter.BlockSize = 64;
        //        encrypter.IV = iv;
        //        encrypter.Key = iv;

        //        using (var memoryStream = new MemoryStream())
        //        {
        //            using (var cryptoStream = new CryptoStream(memoryStream, encrypter.CreateEncryptor(),
        //                CryptoStreamMode.Write))
        //            {
        //                using (StreamWriter swEncrypt = new StreamWriter(cryptoStream))
        //                {
        //                    swEncrypt.Write(toEncrypt);
        //                }
        //            }
        //             result = memoryStream.ToArray();
        //        }
        //    }
        //    return result;
        //}

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
