// Used as playground for testing, faster and easier then running .net core mvc

using Encryption.Hashing;
using Encryption.KeyGenerator;
using System.Security.Cryptography;

IKeyGeneratorFactory keyGeneratorFactory = new KeyGeneratorFactoryImplementation();
IHashingFactory hashingFactory = new HashingFactoryImplementation();

var salt = keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);


var saltKey = Convert.ToBase64String(salt);

var test = hashingFactory.CreateHashing("SHA256");
var result = test.GetHashValueWithSalt("1805", salt);

var test2 = hashingFactory.CreateHashing("SHA256");
var result2 = test2.GetHashValueWithSalt("1805", salt);


Console.WriteLine("Hashingvalue: " + result[1]);

