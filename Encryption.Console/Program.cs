// Used as playground for testing, faster and easier then running .net core mvc

using Encryption.Data;
using Encryption.Data.Models;
using Encryption.Hashing.Factories;
using Encryption.KeyGenerator.Factories;

IKeyGeneratorFactory keyGeneratorFactory = new KeyGeneratorFactoryImplementation();
IHashingFactory hashingFactory = new HashingFactoryImplementation();
DataContext context = new DataContext();




//var test = context.Users.ToList();

var user = new User();
user.FullName = "Steffen Halberg";
user.UserName = "Skywalker";
user.Salt = keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);
var temp = hashingFactory.CreateAlgorithm("SHA256").GetHashValueWithSalt("Kode1234!", user.Salt);
user.Password = temp[1];
context.Users.Add(user);
context.SaveChanges();


//var salt = keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);

//var result = hashingFactory.CreateAlgorithm("SHA1").GetHashValue("Test");
//var result2 = hashingFactory.CreateAlgorithm("SHA1").GetHashValueWithSalt("Test", salt);
//var result3 = hashingFactory.CreateAlgorithm("SHA1").GetHashValueWithKey("Test", salt);


Console.WriteLine("");

