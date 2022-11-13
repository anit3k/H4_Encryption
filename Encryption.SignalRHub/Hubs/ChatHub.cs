using Encryption.Asymmetric.Factories;
using Encryption.KeyGenerator.Factories;
using Encryption.SignalRHub.Models;
using Encryption.Symmetric.Algorithms;
using Encryption.Symmetric.Factories;
using Encryption.Symmetric.Models;
using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography;

namespace Encryption.SignalRHub.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IRSAFactory _rsa;
        private readonly IKeyGeneratorFactory _keyGenService;
        private readonly ICryptographicSetupFactory _cryptoSetup;
        private static CyptographicSetup _aesContainer;
        private readonly IAlgortihm _aesService;
        private readonly InfoModel _infoModel;

        public ChatHub(IRSAFactory rsa, IKeyGeneratorFactory keyGenerator, ISymmetricFactory aes, ICryptographicSetupFactory cryptoSetup, InfoModel model)
        {
            _rsa = rsa;
            _keyGenService = keyGenerator;
            _cryptoSetup = cryptoSetup;
            _aesService = aes.CreateAlgortihm("AES");
            _infoModel = model;
        }
        
        /// <summary>
        /// This task receives encrypted messages from users, and sends back encrypted message
        /// </summary>
        /// <param name="user">User name</param>
        /// <param name="message">encrypted message</param>
        /// <returns>encrypted response</returns>
        public async Task SendEncryptedMessage(string user, string message)
        {
            Console.WriteLine(user + ": " + message);
            _aesContainer.Message = message;
            var decrypted = _aesService.Decrypt(_aesContainer);
            Console.WriteLine(user + ": " +decrypted);

            _aesContainer.Message = "Hello mate, how are you?";
            var encrypted = _aesService.Encrypt(_aesContainer);

            await Clients.All.SendAsync("MessageReceived", "Server", encrypted);
        }

        /// <summary>
        /// Task to recieve public RSA key, to encrypt AES key-set for user to decrypt.
        /// </summary>
        /// <param name="key">RSA public key</param>
        /// <returns></returns>
        public async Task ReceivePublicRSAKey(string key)
        {
            if (key.Contains("<RSAKeyValue>"))
            {
                _aesContainer = _cryptoSetup.Create();
                _aesContainer.IV = _keyGenService.CreateKeyGenerator().GenerateKey(16);
                _aesContainer.Key = _keyGenService.CreateKeyGenerator().GenerateKey(32);
                _aesContainer.CipherMode = CipherMode.ECB;
                _aesContainer.PaddingMode = PaddingMode.PKCS7;
                Console.WriteLine("Public key received");
                _infoModel.PublicKey = key;

                var encryptedAesKeys = _rsa.Create().Encrypt(_infoModel.PublicKey, _aesContainer.IV + ";" + _aesContainer.Key);
                await Clients.All.SendAsync("EncryptedAesKey", encryptedAesKeys);
            }
        }
    }
}
