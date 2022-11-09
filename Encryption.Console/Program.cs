// Used as playground for testing, faster and easier then running .net core mvc
using Encryption.KeyGenerator.Factories;
using Encryption.Symmetric.Factories;
using System.Security.Cryptography;

IKeyGeneratorFactory keyGeneratorFactory = new KeyGeneratorFactoryImplementation();
ISymmetricFactory symmetricFactory = new SymmetricFactoryImplementation();
ICyptographicSetupFactory setupFactory = new CyptographicSetupFactoryImplmentation();

var setup = setupFactory.Create();

TestAES(keyGeneratorFactory, symmetricFactory, setup);
TestTripleDES(keyGeneratorFactory, symmetricFactory, setup);



static void TestAES(IKeyGeneratorFactory keyGeneratorFactory, ISymmetricFactory symmetricFactory, Encryption.Symmetric.Models.CyptographicSetup setup)
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

static void TestTripleDES(IKeyGeneratorFactory keyGeneratorFactory, ISymmetricFactory symmetricFactory, Encryption.Symmetric.Models.CyptographicSetup setup)
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
