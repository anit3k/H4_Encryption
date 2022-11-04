// Used as playground for testing, faster and easier then running .net core mvc

using Encryption.Hashing.Factories;
using Encryption.KeyGenerator.Factories;

IKeyGeneratorFactory keyGeneratorFactory = new KeyGeneratorFactoryImplementation();
IHashingFactory hashingFactory = new HashingFactoryImplementation();

var salt = keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);

var result = hashingFactory.CreateHashing("SHA1").GetHashValue("Test");
var result2 = hashingFactory.CreateHashing("SHA1").GetHashValueWithSalt("Test", salt);
var result3 = hashingFactory.CreateHashing("SHA1").GetHashValueWithKey("Test", salt);


Console.WriteLine("Hashingvalue: " + result[1]);

