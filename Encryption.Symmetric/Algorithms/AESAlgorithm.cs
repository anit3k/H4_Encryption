using Encryption.Symmetric.Models;
using System.Security.Cryptography;

namespace Encryption.Symmetric.Algorithms
{
    public class AESAlgorithm : IAlgortihm
    {
        public string Decrypt(CyptographicSetup setup)
        {
            using (var decrypter = Aes.Create())
            {
                decrypter.Mode = setup.CipherMode;
                decrypter.Padding = setup.PaddingMode;
                decrypter.BlockSize = 128;
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
            using (var encrypter = Aes.Create())
            {
                encrypter.Mode = setup.CipherMode;
                encrypter.Padding = setup.PaddingMode;
                encrypter.BlockSize = 128;
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

        //public string DefaultDecrypt(string toDecrypt, byte[] iv, byte[] key)
        //{
        //    //var temp = Encoding.UTF8.GetString(toDecrypt);
        //    //var decrypt = Encoding.UTF8.GetBytes(temp);

        //    string result = null;
        //    using (var decrypter = Aes.Create())
        //    {
        //        decrypter.Mode = CipherMode.CBC;
        //        decrypter.Padding = PaddingMode.PKCS7;
        //        decrypter.BlockSize = 128;
        //        decrypter.IV = iv;
        //        decrypter.Key = key;

        //        ICryptoTransform decryptor = decrypter.CreateDecryptor(decrypter.Key, decrypter.IV);

        //        using (var memoryStream = new MemoryStream(Convert.FromBase64String(toDecrypt)))
        //        {
        //            using (var cryptoStream = new CryptoStream(memoryStream, decryptor,
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
        //    byte[] result;
        //    using (var encrypter = Aes.Create())
        //    {
        //        encrypter.Mode = CipherMode.CBC;
        //        encrypter.Padding = PaddingMode.PKCS7;
        //        encrypter.BlockSize = 128;
        //        encrypter.IV = iv;
        //        encrypter.Key = key;

        //        ICryptoTransform encryptor = encrypter.CreateEncryptor(encrypter.Key, encrypter.IV);

        //        using (var memoryStream = new MemoryStream())
        //        {
        //            using (var cryptoStream = new CryptoStream(memoryStream, encryptor,
        //                CryptoStreamMode.Write))
        //            {
        //                using (StreamWriter swEncrypt = new StreamWriter(cryptoStream))
        //                {
        //                    swEncrypt.Write(toEncrypt);
        //                }
        //                result = memoryStream.ToArray();
        //            }
        //        }
        //    }

        //    var temp = Encoding.UTF8.GetString(result);
        //    return Encoding.UTF8.GetBytes(temp);

        //    //return result;
        //}
    }
}
