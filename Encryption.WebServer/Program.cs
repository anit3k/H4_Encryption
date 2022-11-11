using Encryption.Asymmetric.Factories;
using Encryption.KeyGenerator.Factories;
using Encryption.KeyGenerator.Generators;
using Encryption.Symmetric.Algorithms;
using Encryption.Symmetric.Factories;
using Encryption.Symmetric.Models;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;

IRSAFactory rsaService = new RSAFactoryImplementation();
var clientRsaPublicKey = "";

IAlgortihm aesService = new SymmetricFactoryImplementation().CreateAlgortihm("AES");

IGenerator aesKeygen = new KeyGeneratorFactoryImplementation().CreateKeyGenerator();
var ivKey = aesKeygen.GenerateKey(16);
var aesKey = aesKeygen.GenerateKey(32);


Console.Title = "Server";
var builder = WebApplication.CreateBuilder();
builder.WebHost.UseUrls("http://localhost:6666");
var app = builder.Build();
app.UseWebSockets();
app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var buffer = new byte[512];
        int workflow = 2;
        using (var webSocket = await context.WebSockets.AcceptWebSocketAsync())
        {
            while (true)
            {
                var response0 = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                switch (workflow)
                {
                    case 2: // request RSA public key
                        if (Encoding.ASCII.GetString(buffer, 0, response0.Count).Contains("CLIENT 1"))
                        {
                            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, response0.Count));

                            await webSocket.SendAsync(Encoding.ASCII.GetBytes($"SERVER 2: Hello Client, send public RSA key"), WebSocketMessageType.Text, true, CancellationToken.None);
                            Console.WriteLine("SERVER 2: Hello Client, send public RSA key");
                            workflow = 4;
                        }
                        break;
                    case 4: // retrieve RSA public key, and send back AES keys
                        if (Encoding.ASCII.GetString(buffer, 0, response0.Count).Contains("<RSAKeyValue>"))
                        {
                            var clientResponse = Encoding.ASCII.GetString(buffer, 0, response0.Count);
                            Console.WriteLine("SERVER 4: Retriving client public key, and encrypt IV and Key for AES");
                            var encryptedIvKey = rsaService.Create().Encrypt(clientResponse, ivKey + ";" + aesKey);
                            await webSocket.SendAsync(Encoding.ASCII.GetBytes($"SERVER 4: " + encryptedIvKey), WebSocketMessageType.Text, true, CancellationToken.None);
                            Console.WriteLine("SERVER 4: Sending AES IV and Key");
                            workflow = 6;
                        }
                        break;
                    case 6: // retrive AES encrypted message, and reply with AES encrypted answer
                        if (Encoding.ASCII.GetString(buffer, 0, response0.Count).Contains("CLIENT 5"))
                        {
                            var aesDecryptedMessageFromclient = aesService.Decrypt(new CyptographicSetup()
                            {
                                Message = Encoding.ASCII.GetString(buffer, 0, response0.Count).Substring(9),
                                IV = ivKey,
                                Key = aesKey,
                                CipherMode = CipherMode.ECB,
                                PaddingMode = PaddingMode.PKCS7,
                            });
                            Console.WriteLine("Client: " + aesDecryptedMessageFromclient);
                            Console.WriteLine("SERVER: Encrypt reply and send");

                            var aesEncryptedMessageToClient = aesService.Encrypt(new CyptographicSetup()
                            {
                                Message = "The numbers are (6, 12, 15, 19, 26, 28, 29)",
                                IV = ivKey,
                                Key = aesKey,
                                CipherMode = CipherMode.ECB,
                                PaddingMode = PaddingMode.PKCS7,
                            });

                            await webSocket.SendAsync(Encoding.ASCII.GetBytes($"SERVER 6: " + aesEncryptedMessageToClient), WebSocketMessageType.Text, true, CancellationToken.None);
                            Console.WriteLine("SERVER 6: Sending encrypted response");

                            workflow = 8;
                        }
                        break;
                    case 8:
                        if (Encoding.ASCII.GetString(buffer, 0, response0.Count).Contains("CLIENT 7"))
                        {
                            var aesDecryptedMessageFromclient = aesService.Decrypt(new CyptographicSetup()
                            {
                                Message = Encoding.ASCII.GetString(buffer, 0, response0.Count).Substring(9),
                                IV = ivKey,
                                Key = aesKey,
                                CipherMode = CipherMode.ECB,
                                PaddingMode = PaddingMode.PKCS7,
                            });
                            Console.WriteLine("Client: " + aesDecryptedMessageFromclient);

                            var aesEncryptedMessageToClient = aesService.Encrypt(new CyptographicSetup()
                            {
                                Message = "You are welcome",
                                IV = ivKey,
                                Key = aesKey,
                                CipherMode = CipherMode.ECB,
                                PaddingMode = PaddingMode.PKCS7,
                            });

                            await webSocket.SendAsync(Encoding.ASCII.GetBytes($"SERVER 8; " + aesEncryptedMessageToClient), WebSocketMessageType.Text, true, CancellationToken.None);
                            Console.WriteLine("SERVER 8: reply");
                            Console.WriteLine("Terminate connection");
                        }
                        break;
                    default:
                        Console.WriteLine("close connection");
                        break;
                }
            }
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});
await app.RunAsync();