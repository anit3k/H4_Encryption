// Used as playground for testing, faster and easier then running .net core mvc
using Encryption.Asymmetric.Factories;
using Encryption.KeyGenerator.Factories;
using Encryption.Symmetric.Factories;
using Encryption.Symmetric.Models;
using System.Security.Cryptography;
using System.Text;



#region RSA asymmetric encryption PoC
IRSAFactory rSAFactory = new RSAFactoryImplementation();
var keysGenerates = rSAFactory.Create().GenerateNewKeySet();

var rSA = new RSAFactoryImplementation();
Dictionary<string, string> keys = rSA.Create().GenerateNewKeySet();
string data = "Hello World, this text is encrypted using the RSA Cryptographic Algorithm, this is fun, Hello again,";
var sizw = Encoding.Unicode.GetBytes(data);
string encrypted = rSA.Create().Encrypt(keys["Public"], data);
string decrypted = rSA.Create().Decrypt(keys["Private"], Convert.FromBase64String(encrypted));

var rSANew = new RSAFactoryImplementation();
Dictionary<string, string> keysNew = rSANew.Create().GenerateNewKeySet();
string dataNew = "Hello World, this text is encrypted using the RSA Cryptographic Algorithm, this is fun";
string encryptedNew = rSANew.Create().Encrypt(keysNew["Public"], dataNew);
string decryptedNew = rSANew.Create().Decrypt(keysNew["Private"], Convert.FromBase64String(encryptedNew));
#endregion



#region Symmetric TripleDES and AES PoC

IKeyGeneratorFactory keyGeneratorFactory = new KeyGeneratorFactoryImplementation();
ISymmetricFactory symmetricFactory = new SymmetricFactoryImplementation();
ICryptographicSetupFactory setupFactory = new CryptographicSetupFactoryImplmentation();

var setup = setupFactory.Create();

TestAES(keyGeneratorFactory, symmetricFactory, setup);
TestTripleDES(keyGeneratorFactory, symmetricFactory, setup);



static void TestAES(IKeyGeneratorFactory keyGeneratorFactory, ISymmetricFactory symmetricFactory, CyptographicSetup setup)
{
    Console.WriteLine("AES with key of 256 bit, CBC cipher and padding PKCS7");
    setup.Message = "Hello World";
    setup.IV = keyGeneratorFactory.CreateKeyGenerator().GenerateKey(16);
    setup.Key = keyGeneratorFactory.CreateKeyGenerator().GenerateKey(32);
    setup.CipherMode = CipherMode.CBC;
    setup.PaddingMode = PaddingMode.PKCS7;
    Console.WriteLine("Original message: " + setup.Message);

    var encryptedMessage = symmetricFactory.CreateAlgortihm("AES").Encrypt(setup);
    Console.WriteLine("Encrypted: " + encryptedMessage);

    setup.Message = encryptedMessage;

    var decryptedMessage = symmetricFactory.CreateAlgortihm("AES").Decrypt(setup);
    Console.WriteLine("Decrypted: " + decryptedMessage);
    Console.WriteLine();
}

static void TestTripleDES(IKeyGeneratorFactory keyGeneratorFactory, ISymmetricFactory symmetricFactory, CyptographicSetup setup)
{
    Console.WriteLine("TripleDES with key of 196 bit, CBC cipher and padding PKCS7");
    setup.Message = "Hello World";
    setup.IV = keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);
    setup.Key = keyGeneratorFactory.CreateKeyGenerator().GenerateKey(16);
    setup.CipherMode = CipherMode.CFB;
    setup.PaddingMode = PaddingMode.ANSIX923;
    Console.WriteLine("Original message: " + setup.Message);

    var encryptedMessage = symmetricFactory.CreateAlgortihm("TripleDES").Encrypt(setup);
    Console.WriteLine("Encrypted: " + encryptedMessage);

    setup.Message = encryptedMessage;

    var decryptedMessage = symmetricFactory.CreateAlgortihm("TripleDES").Decrypt(setup);
    Console.WriteLine("Decrypted: " + decryptedMessage);
    Console.WriteLine();
}

#endregion