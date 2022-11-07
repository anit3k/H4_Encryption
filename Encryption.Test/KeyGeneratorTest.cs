using Encryption.KeyGenerator.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Test
{
    public class KeyGeneratorTest
    {
        IKeyGeneratorFactory _keyGeneratorFactory;
        [SetUp]
        public void Setup()
        {
            _keyGeneratorFactory = new KeyGeneratorFactoryImplementation();
        }

        [Test]
        public void KeyGenerator_ShouldWork()
        {
            var key = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);
            var secondKey = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);
            Assert.That(key, Is.Not.EqualTo(secondKey));
            Assert.That(key, Is.Not.SameAs(secondKey));
        }
    }
}
