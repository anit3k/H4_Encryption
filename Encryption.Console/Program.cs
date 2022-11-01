// Used as playground for testing, faster and easier then running .net core mvc

using Encryption.Hashing;

IHashingFactory hashingFactory = new HashingFactoryImplementation();

var test = hashingFactory.CreateHashing("SHA512");
var result = test.GetHashValue("1805");

Console.WriteLine("Hashingvalue: " + result);

