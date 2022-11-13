using Encryption.KeyGenerator.Factories;
using Encryption.Symmetric.Factories;
using System.Security.Cryptography;

namespace Encryption.Test
{
    public class SymmetricTest
    {
        private KeyGeneratorFactoryImplementation _keyGeneratorFactory;
        private SymmetricFactoryImplementation _symmetricFactory;
        private CryptographicSetupFactoryImplmentation _setupFactory;

        [SetUp]
        public void Setup()
        {
            _keyGeneratorFactory = new KeyGeneratorFactoryImplementation();
            _symmetricFactory = new SymmetricFactoryImplementation();
            _setupFactory = new CryptographicSetupFactoryImplmentation();
        }

        #region AES Test

        [Test]
        public void AES_ShouldWork_Key256bit_CBC_PKCS7()
        {
            var keyGen = _keyGeneratorFactory.CreateKeyGenerator();
            var cryptoService = _symmetricFactory.CreateAlgortihm("AES");
            var setup = _setupFactory.Create();

            string originalMessage = "Hello World, this is a encrypted test";
            setup.Message = originalMessage;
            setup.IV = keyGen.GenerateKey(16);
            setup.Key = keyGen.GenerateKey(32);
            setup.CipherMode = CipherMode.CBC;
            setup.PaddingMode = PaddingMode.PKCS7;

            var encryptedMessage = cryptoService.Encrypt(setup);
            setup.Message = encryptedMessage;
            var decryptedMessage = cryptoService.Decrypt(setup);

            Assert.That(encryptedMessage, Is.Not.EqualTo(decryptedMessage));
            Assert.That(encryptedMessage, Is.Not.Null);
            Assert.That(encryptedMessage, Is.Not.EqualTo(originalMessage));
            Assert.That(decryptedMessage, Is.Not.Null);
            Assert.That(decryptedMessage, Is.EqualTo(originalMessage));
        }

        [Test]
        public void AES_ShouldWork_Key128bit_ECB_ISO10126()
        {
            var keyGen = _keyGeneratorFactory.CreateKeyGenerator();
            var cryptoService = _symmetricFactory.CreateAlgortihm("AES");
            var setup = _setupFactory.Create();

            string originalMessage = "Hello World, I am soon to be the king of encryption";
            setup.Message = originalMessage;
            setup.IV = keyGen.GenerateKey(16);
            setup.Key = keyGen.GenerateKey(16);
            setup.CipherMode = CipherMode.ECB;
            setup.PaddingMode = PaddingMode.ISO10126;

            var encryptedMessage = cryptoService.Encrypt(setup);
            setup.Message = encryptedMessage;
            var decryptedMessage = cryptoService.Decrypt(setup);

            Assert.That(encryptedMessage, Is.Not.EqualTo(decryptedMessage));
            Assert.That(encryptedMessage, Is.Not.Null);
            Assert.That(encryptedMessage, Is.Not.EqualTo(originalMessage));
            Assert.That(decryptedMessage, Is.Not.Null);
            Assert.That(decryptedMessage, Is.EqualTo(originalMessage));
        }

        [Test]
        public void AES_ShouldWork_Key256bit_CFB_PKCS7()
        {
            var keyGen = _keyGeneratorFactory.CreateKeyGenerator();
            var cryptoService = _symmetricFactory.CreateAlgortihm("AES");
            var setup = _setupFactory.Create();

            string originalMessage = "Hello World, this is a encrypted test";
            setup.Message = originalMessage;
            setup.IV = keyGen.GenerateKey(16);
            setup.Key = keyGen.GenerateKey(32);
            setup.CipherMode = CipherMode.CFB;
            setup.PaddingMode = PaddingMode.PKCS7;

            var encryptedMessage = cryptoService.Encrypt(setup);
            setup.Message = encryptedMessage;
            var decryptedMessage = cryptoService.Decrypt(setup);

            Assert.That(encryptedMessage, Is.Not.EqualTo(decryptedMessage));
            Assert.That(encryptedMessage, Is.Not.EqualTo(originalMessage));
            Assert.That(decryptedMessage, Is.EqualTo(originalMessage));
        }

        [Test]
        public void AES_ShouldWork_Key256bit_CTS_ZEROS()
        {
            var keyGen = _keyGeneratorFactory.CreateKeyGenerator();
            var cryptoService = _symmetricFactory.CreateAlgortihm("AES");
            var setup = _setupFactory.Create();

            string originalMessage = "Hello World, this is a encrypted test";
            setup.Message = originalMessage;
            setup.IV = keyGen.GenerateKey(16);
            setup.Key = keyGen.GenerateKey(32);
            setup.CipherMode = CipherMode.CBC;
            setup.PaddingMode = PaddingMode.Zeros;

            var encryptedMessage = cryptoService.Encrypt(setup);
            setup.Message = encryptedMessage;
            var decryptedMessage = cryptoService.Decrypt(setup);

            Assert.That(encryptedMessage, Is.Not.EqualTo(decryptedMessage));
            Assert.That(encryptedMessage, Is.Not.EqualTo(originalMessage));
            Assert.That(decryptedMessage, Is.Not.EqualTo(originalMessage));
        }

        [Test]
        public void AES_ShouldWork_Key256bit_CFB_ISO10126()
        {
            var keyGen = _keyGeneratorFactory.CreateKeyGenerator();
            var cryptoService = _symmetricFactory.CreateAlgortihm("AES");
            var setup = _setupFactory.Create();

            string originalMessage = "Hello World, this is a encrypted test";
            setup.Message = originalMessage;
            setup.IV = keyGen.GenerateKey(16);
            setup.Key = keyGen.GenerateKey(32);
            setup.CipherMode = CipherMode.CFB;
            setup.PaddingMode = PaddingMode.ISO10126;

            var encryptedMessage = cryptoService.Encrypt(setup);
            setup.Message = encryptedMessage;
            var decryptedMessage = cryptoService.Decrypt(setup);

            Assert.That(encryptedMessage, Is.Not.EqualTo(decryptedMessage));
            Assert.That(encryptedMessage, Is.Not.EqualTo(originalMessage));
            Assert.That(decryptedMessage, Is.EqualTo(originalMessage));
        }

        [Test]
        public void AES_ShouldWork_Key256bit_ECB_ANSIX923()
        {
            var keyGen = _keyGeneratorFactory.CreateKeyGenerator();
            var cryptoService = _symmetricFactory.CreateAlgortihm("AES");
            var setup = _setupFactory.Create();

            string originalMessage = "Hello World, this is a encrypted test";
            setup.Message = originalMessage;
            setup.IV = keyGen.GenerateKey(16);
            setup.Key = keyGen.GenerateKey(32);
            setup.CipherMode = CipherMode.ECB;
            setup.PaddingMode = PaddingMode.ANSIX923;

            var encryptedMessage = cryptoService.Encrypt(setup);
            setup.Message = encryptedMessage;
            var decryptedMessage = cryptoService.Decrypt(setup);

            Assert.That(encryptedMessage, Is.Not.EqualTo(decryptedMessage));
            Assert.That(encryptedMessage, Is.Not.EqualTo(originalMessage));
            Assert.That(decryptedMessage, Is.EqualTo(originalMessage));
        }
        #endregion

        #region TripleDES Test

        [Test]
        public void TripleDES_ShouldWork_Key192bit_ECB_PKCS7()
        {
            var keyGen = _keyGeneratorFactory.CreateKeyGenerator();
            var cryptoService = _symmetricFactory.CreateAlgortihm("TripleDES");
            var setup = _setupFactory.Create();

            string originalMessage = "Hello World, this is a encrypted test";
            setup.Message = originalMessage;
            setup.IV = keyGen.GenerateKey(8);
            setup.Key = keyGen.GenerateKey(24);
            setup.CipherMode = CipherMode.ECB;
            setup.PaddingMode = PaddingMode.PKCS7;

            var encryptedMessage = cryptoService.Encrypt(setup);
            setup.Message = encryptedMessage;
            var decryptedMessage = cryptoService.Decrypt(setup);

            Assert.That(encryptedMessage, Is.Not.EqualTo(decryptedMessage));
            Assert.That(encryptedMessage, Is.Not.Null);
            Assert.That(encryptedMessage, Is.Not.EqualTo(originalMessage));
            Assert.That(decryptedMessage, Is.Not.Null);
            Assert.That(decryptedMessage, Is.EqualTo(originalMessage));
        }

        [Test]
        public void TripleDES_ShouldWork_Key128bit_CBC_ISO10126()
        {
            var keyGen = _keyGeneratorFactory.CreateKeyGenerator();
            var cryptoService = _symmetricFactory.CreateAlgortihm("TripleDES");
            var setup = _setupFactory.Create();

            string originalMessage = "Hello World, this is a encrypted test";
            setup.Message = originalMessage;
            setup.IV = keyGen.GenerateKey(8);
            setup.Key = keyGen.GenerateKey(16);
            setup.CipherMode = CipherMode.CBC;
            setup.PaddingMode = PaddingMode.ISO10126;

            var encryptedMessage = cryptoService.Encrypt(setup);
            setup.Message = encryptedMessage;
            var decryptedMessage = cryptoService.Decrypt(setup);

            Assert.That(encryptedMessage, Is.Not.EqualTo(decryptedMessage));
            Assert.That(encryptedMessage, Is.Not.Null);
            Assert.That(encryptedMessage, Is.Not.EqualTo(originalMessage));
            Assert.That(decryptedMessage, Is.Not.Null);
            Assert.That(decryptedMessage, Is.EqualTo(originalMessage));
        }

        [Test]
        public void TripleDES_ShouldWork_Key192bit_CFB_ANSIX923()
        {
            var keyGen = _keyGeneratorFactory.CreateKeyGenerator();
            var cryptoService = _symmetricFactory.CreateAlgortihm("TripleDES");
            var setup = _setupFactory.Create();

            string originalMessage = "Hello World, this is a encrypted test";
            setup.Message = originalMessage;
            setup.IV = keyGen.GenerateKey(8);
            setup.Key = keyGen.GenerateKey(24);
            setup.CipherMode = CipherMode.CFB;
            setup.PaddingMode = PaddingMode.ANSIX923;

            var encryptedMessage = cryptoService.Encrypt(setup);
            setup.Message = encryptedMessage;
            var decryptedMessage = cryptoService.Decrypt(setup);

            Assert.That(encryptedMessage, Is.Not.EqualTo(decryptedMessage));
            Assert.That(encryptedMessage, Is.Not.Null);
            Assert.That(encryptedMessage, Is.Not.EqualTo(originalMessage));
            Assert.That(decryptedMessage, Is.Not.Null);
            Assert.That(decryptedMessage, Is.EqualTo(originalMessage));
        }
        #endregion
    }
}
