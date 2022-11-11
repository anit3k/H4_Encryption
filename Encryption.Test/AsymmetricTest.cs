using Encryption.Asymmetric.Algorithms;
using Encryption.Asymmetric.Factories;

namespace Encryption.Test
{
    public class AsymmetricTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RSA_ShouldWork()
        {
            var rSA = new RSAFactoryImplementation();
            Dictionary<string, string> keys = rSA.Create().GenerateNewKeySet();
            string data = "Hello World, this text is encrypted using the RSA Cryptographic Algorithm, this is fun";
            string encrypted = rSA.Create().Encrypt(keys["Public"], data);
            string decrypted = rSA.Create().Decrypt(keys["Private"], Convert.FromBase64String(encrypted));

            Assert.That(encrypted, Is.Not.Null);
            Assert.That(decrypted, Is.Not.Null);
            Assert.That(encrypted, Is.Not.EqualTo(decrypted));
            Assert.That(decrypted, Is.EqualTo(data));
        }

        [Test]
        public void RSA_ShouldNotWork()
        {
            var rSA = new RSAFactoryImplementation();
            Dictionary<string, string> keys = rSA.Create().GenerateNewKeySet();
            string data = "Hello World, this text is encrypted using the RSA Cryptographic Algorithm, this is fun";
            string encrypted = rSA.Create().Encrypt(keys["Public"], data);
            string decrypted = rSA.Create().Decrypt(keys["Private"], Convert.FromBase64String(encrypted));

            var rSANew = new RSAFactoryImplementation();
            Dictionary<string, string> keysNew = rSANew.Create().GenerateNewKeySet();
            string dataNew = "Hello World, this text is encrypted using the RSA Cryptographic Algorithm, this is fun";
            string encryptedNew = rSANew.Create().Encrypt(keysNew["Public"], dataNew);
            string decryptedNew = rSANew.Create().Decrypt(keysNew["Private"], Convert.FromBase64String(encryptedNew));

            Assert.That(encrypted, Is.Not.EqualTo(encryptedNew));
            Assert.That(decrypted, Is.EqualTo(decryptedNew));
            Assert.That(keys, Is.Not.EqualTo(keysNew));
            Assert.That(data, Is.EqualTo(dataNew));
        }
    }
}
