using Encryption.CaesarCipher.Factories;

namespace Encryption.Test
{
    public class CaesarCipherTest
    {
        ICaesarCipherFactory _caesarCipherFactory;

        [SetUp]
        public void Setup()
        {
            _caesarCipherFactory = new CaesarCipherFactoryImplementation(); 
        }

        [Test]
        public void Encrypt_ShouldWork()
        {
            string textToCipher = "Hello World!";
            string encryptetText = _caesarCipherFactory.Create().CipherText(textToCipher, 10, false);
            string decryptetText = _caesarCipherFactory.Create().CipherText(encryptetText, 10, true);
            string encryptetTextRaw = _caesarCipherFactory.Create().CipherText("Hello World!", 10, false);
            string decryptetTextRaw = _caesarCipherFactory.Create().CipherText(encryptetTextRaw, 10, true);

            Assert.That(decryptetText, Is.EqualTo(textToCipher));
            Assert.That(textToCipher, Is.Not.EqualTo(encryptetText));
            Assert.That(decryptetTextRaw, Is.EqualTo("Hello World!"));
            Assert.That(textToCipher, Is.Not.EqualTo(encryptetTextRaw));
        }

        [Test]
        public void Encrypt_NoAlphabetChars()
        {
            string textToCipher = "123456!?&";
            string encryptetText = _caesarCipherFactory.Create().CipherText(textToCipher, 10, false);
            string decryptetText = _caesarCipherFactory.Create().CipherText(encryptetText, 10, true);

            Assert.That(decryptetText, Is.EqualTo(textToCipher));
            Assert.That(textToCipher, Is.EqualTo(encryptetText));
        }
    }
}
