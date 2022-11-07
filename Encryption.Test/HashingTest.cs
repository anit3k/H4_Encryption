using Encryption.Hashing.Factories;
using Encryption.KeyGenerator.Factories;

namespace Encryption.Test
{
    public class HashingTest
    {
        IHashingFactory _hashingFactory;
        IKeyGeneratorFactory _keyGeneratorFactory;

        [SetUp]
        public void Setup()
        {
            _hashingFactory = new HashingFactoryImplementation();
            _keyGeneratorFactory = new KeyGeneratorFactoryImplementation();
        }

        #region HashingOrdinary
        [Test]
        public void SHA1Hashing_Succes()
        {
            var result = _hashingFactory.CreateAlgorithm("SHA1").GetHashValue("test");
            var expected = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3"; 
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void SHA1Hashing_LowerAndUpper_Differnt_Hashvalues()
        {
            var resultLowerCase = _hashingFactory.CreateAlgorithm("SHA1").GetHashValue("test");
            var resultUpperCase = _hashingFactory.CreateAlgorithm("SHA1").GetHashValue("TEST");

            var expectedLowerCase = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3";
            var expectedUpperCase = "984816fd329622876e14907634264e6f332e9fb3";
            Assert.That(resultLowerCase, Is.EqualTo(expectedLowerCase));
            Assert.That(resultUpperCase, Is.EqualTo(expectedUpperCase));
            Assert.That(resultUpperCase, Is.Not.EqualTo(expectedLowerCase));
            Assert.That(resultLowerCase, Is.Not.EqualTo(expectedUpperCase));
        }

        [Test]
        public void SHA1Hashing_ShouldNotWork()
        {
            var resultLowerCase = _hashingFactory.CreateAlgorithm("SHA1").GetHashValue("test");
            var resultUpperCase = _hashingFactory.CreateAlgorithm("SHA1").GetHashValue("TEST");
            Assert.That(resultUpperCase, Is.Not.EqualTo(resultLowerCase));
        }

        [Test]
        public void AllHashingTypes_ShouldWork()
        {
            var hashingTypes = new Dictionary<string, string>();
            hashingTypes.Add("SHA1", "password1234");
            hashingTypes.Add("SHA256", "password1234");
            hashingTypes.Add("SHA384", "password1234");
            hashingTypes.Add("SHA512", "password1234");
            hashingTypes.Add("MD5", "password1234");

            foreach (var item in hashingTypes)
            {
                var result = _hashingFactory.CreateAlgorithm(item.Key).GetHashValue(item.Value);
                var result2 = _hashingFactory.CreateAlgorithm(item.Key).GetHashValue(item.Value);
                Assert.That(result2, Is.EqualTo(result));
                Assert.That(result2, Is.Not.SameAs(result));
            }
        }
        #endregion
               
        #region HashingWithSalt
        [Test]
        public void SHA1HashingWithSalt_ShouldWork()
        {
            var salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);
            var result = _hashingFactory.CreateAlgorithm("SHA1").GetHashValueWithSalt("test", salt);
            var resultSameValue = _hashingFactory.CreateAlgorithm("SHA1").GetHashValueWithSalt("test", salt);

            Assert.That(result, Is.EqualTo(resultSameValue));
            Assert.That(result, Is.EqualTo(result));
        }

        public void AllHashingTypesWithSalt_ShouldWork()
        {
            var salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);

            var hashingTypes = new Dictionary<string, string>();
            hashingTypes.Add("SHA1", "password1234");
            hashingTypes.Add("SHA256", "password1234");
            hashingTypes.Add("SHA384", "password1234");
            hashingTypes.Add("SHA512", "password1234");
            hashingTypes.Add("MD5", "password1234");

            foreach (var item in hashingTypes)
            {
                var result = _hashingFactory.CreateAlgorithm(item.Key).GetHashValueWithSalt(item.Value, salt);
                var result2 = _hashingFactory.CreateAlgorithm(item.Key).GetHashValueWithSalt(item.Value, salt);
                Assert.That(result2, Is.EqualTo(result));
                Assert.That(result2, Is.Not.SameAs(result));
            }
        }

        [Test]
        public void AllHashingTypesWithSalt_ShouldNotWork()
        {
            var salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);

            var hashingTypes = new Dictionary<string, string>();
            hashingTypes.Add("SHA1", "password1234");
            hashingTypes.Add("SHA256", "password1234");
            hashingTypes.Add("SHA384", "password1234");
            hashingTypes.Add("SHA512", "password1234");
            hashingTypes.Add("MD5", "password1234");

            foreach (var item in hashingTypes)
            {
                var result = _hashingFactory.CreateAlgorithm(item.Key).GetHashValueWithSalt(item.Value, salt);
                var resultWithAnotherSaltKey = _hashingFactory.CreateAlgorithm(item.Key).GetHashValueWithSalt(item.Value, _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8));
                var resultWithUpperCase = _hashingFactory.CreateAlgorithm(item.Key).GetHashValueWithSalt("PASSWORD1234", salt);
                Assert.That(resultWithAnotherSaltKey, Is.Not.EqualTo(result));
                Assert.That(resultWithAnotherSaltKey, Is.Not.SameAs(result));
                Assert.That(resultWithUpperCase, Is.Not.EqualTo(result));
                Assert.That(resultWithUpperCase, Is.Not.SameAs(result));
            }
        }
        #endregion

        #region HashingWithKey

        [Test]
        public void SHA1HashingWithKey_ShouldWork()
        {
            var salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(10);

            var result = _hashingFactory.CreateAlgorithm("SHA1").GetHashValueWithKey("test", salt);
            var resultSameValue = _hashingFactory.CreateAlgorithm("SHA1").GetHashValueWithKey("test", salt);

            Assert.That(result, Is.EqualTo(resultSameValue));
            Assert.That(result, Is.EqualTo(result));
        }

        public void AllHashingTypesWithKey_ShouldWork()
        {
            var salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(32);

            var hashingTypes = new Dictionary<string, string>();
            hashingTypes.Add("SHA1", "password1234");
            hashingTypes.Add("SHA256", "password1234");
            hashingTypes.Add("SHA384", "password1234");
            hashingTypes.Add("SHA512", "password1234");
            hashingTypes.Add("MD5", "password1234");

            foreach (var item in hashingTypes)
            {
                var result = _hashingFactory.CreateAlgorithm(item.Key).GetHashValueWithKey(item.Value, salt);
                var result2 = _hashingFactory.CreateAlgorithm(item.Key).GetHashValueWithKey(item.Value, salt);
                Assert.That(result2, Is.EqualTo(result));
                Assert.That(result2, Is.Not.SameAs(result));
            }
        }

        [Test]
        public void AllHashingTypesWithKéy_ShouldNotWork()
        {
            var salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(16);

            var hashingTypes = new Dictionary<string, string>();
            hashingTypes.Add("SHA1", "password1234");
            hashingTypes.Add("SHA256", "password1234");
            hashingTypes.Add("SHA384", "password1234");
            hashingTypes.Add("SHA512", "password1234");
            hashingTypes.Add("MD5", "password1234");

            foreach (var item in hashingTypes)
            {
                var result = _hashingFactory.CreateAlgorithm(item.Key).GetHashValueWithKey(item.Value, salt);
                var resultWithAnotherSaltKey = _hashingFactory.CreateAlgorithm(item.Key).GetHashValueWithKey(item.Value, _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(16));
                var resultWithUpperCase = _hashingFactory.CreateAlgorithm(item.Key).GetHashValueWithKey("PASSWORD1234", salt);
                Assert.That(resultWithAnotherSaltKey, Is.Not.EqualTo(result));
                Assert.That(resultWithAnotherSaltKey, Is.Not.SameAs(result));
                Assert.That(resultWithUpperCase, Is.Not.EqualTo(result));
                Assert.That(resultWithUpperCase, Is.Not.SameAs(result));
            }
        }

        #endregion

    }
}
