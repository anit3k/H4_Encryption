﻿using Encryption.Hashing;
using Encryption.KeyGenerator;

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
            var result = _hashingFactory.CreateHashing("SHA1").GetHashValue("test");
            var expected = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3"; 
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void SHA1Hashing_LowerAndUpper_Differnt_Hashvalues()
        {
            var resultLowerCase = _hashingFactory.CreateHashing("SHA1").GetHashValue("test");
            var resultUpperCase = _hashingFactory.CreateHashing("SHA1").GetHashValue("TEST");

            var expectedLowerCase = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3";
            var expectedUpperCase = "984816fd329622876e14907634264e6f332e9fb3";
            Assert.That(resultLowerCase, Is.EqualTo(expectedLowerCase));
            Assert.That(resultUpperCase, Is.EqualTo(expectedUpperCase));
            Assert.That(resultUpperCase, Is.Not.EqualTo(expectedLowerCase));
            Assert.That(resultLowerCase, Is.Not.EqualTo(expectedUpperCase));
        }

        [Test]
        public void SHA1Hashing_Should_Fail()
        {
            var resultLowerCase = _hashingFactory.CreateHashing("SHA1").GetHashValue("test");
            var resultUpperCase = _hashingFactory.CreateHashing("SHA1").GetHashValue("TEST");
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
                var result = _hashingFactory.CreateHashing(item.Key).GetHashValue(item.Value);
                var result2 = _hashingFactory.CreateHashing(item.Key).GetHashValue(item.Value);
                Assert.That(result2, Is.EqualTo(result));
                Assert.That(result2, Is.Not.SameAs(result));
            }
        }
        #endregion

        #region HashingWithSalt

        [Test]
        public void SHA1HashingWithSalt_ShouldWork()
        {
            var saltLength = 8;
            var salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(saltLength);
            var saltAsString = Convert.ToBase64String(salt);

            var result = _hashingFactory.CreateHashing("SHA1").GetHashValueWithSalt("test", salt);
            var resultSameValue = _hashingFactory.CreateHashing("SHA1").GetHashValueWithSalt("test", salt);

            var resultConvertedFromString = _hashingFactory.CreateHashing("SHA1").GetHashValueWithSalt("test", Convert.FromBase64String(saltAsString));
            Assert.That(result, Is.EqualTo(resultSameValue));
            Assert.That(result, Is.EqualTo(resultConvertedFromString));
        }

        public void AllHashingTypesWithSalt_ShouldWork()
        {
            var saltLength = 8;
            var salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(saltLength);
            var saltAsString = Convert.ToBase64String(salt);

            var hashingTypes = new Dictionary<string, string>();
            hashingTypes.Add("SHA1", "password1234");
            hashingTypes.Add("SHA256", "password1234");
            hashingTypes.Add("SHA384", "password1234");
            hashingTypes.Add("SHA512", "password1234");
            hashingTypes.Add("MD5", "password1234");

            foreach (var item in hashingTypes)
            {
                var result = _hashingFactory.CreateHashing(item.Key).GetHashValueWithSalt(item.Value, salt);
                var result2 = _hashingFactory.CreateHashing(item.Key).GetHashValueWithSalt(item.Value, Convert.FromBase64String(saltAsString));
                Assert.That(result2, Is.EqualTo(result));
                Assert.That(result2, Is.Not.SameAs(result));
            }
        }

        [Test]
        public void AllHashingTypesWithSalt_ShouldFail()
        {
            var saltLength = 8;
            var salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(saltLength);
            var saltAsString = Convert.ToBase64String(salt);

            var hashingTypes = new Dictionary<string, string>();
            hashingTypes.Add("SHA1", "password1234");
            hashingTypes.Add("SHA256", "password1234");
            hashingTypes.Add("SHA384", "password1234");
            hashingTypes.Add("SHA512", "password1234");
            hashingTypes.Add("MD5", "password1234");

            foreach (var item in hashingTypes)
            {
                var result = _hashingFactory.CreateHashing(item.Key).GetHashValueWithSalt(item.Value, salt);
                var result2 = _hashingFactory.CreateHashing(item.Key).GetHashValueWithSalt(item.Value, Convert.FromBase64String("Rand1234"));
                Assert.That(result2, Is.Not.EqualTo(result));
                Assert.That(result2, Is.Not.SameAs(result));
            }
        }
        #endregion

    }
}
