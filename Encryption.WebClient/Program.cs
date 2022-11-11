using Encryption.Asymmetric.Factories;
using Encryption.Symmetric.Algorithms;
using Encryption.Symmetric.Factories;
using Encryption.Symmetric.Models;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;

IRSAFactory rsaService = new RSAFactoryImplementation();
var rsaKeySet = rsaService.Create().GenerateNewKeySet();

IAlgortihm aesService = new SymmetricFactoryImplementation().CreateAlgortihm("AES");
var ivKey = String.Empty;
var aesKey = String.Empty;

Console.Title = "Client";
using (var ws = new ClientWebSocket())
{
    await ws.ConnectAsync(new Uri("ws://localhost:6666/ws"), CancellationToken.None);
    var buffer = new byte[512];
    int workflow = 1;
    string fromClientText = "";
    while (ws.State == WebSocketState.Open)
    {
        switch (workflow)
        {
            case 1: 
                // send hello to server, and retrieve answer
                Console.WriteLine("Press Key: Send Hello");
                Console.ReadKey();
                await ws.SendAsync(Encoding.ASCII.GetBytes($"CLIENT 1: Hey Server"), WebSocketMessageType.Text, true, CancellationToken.None);

                var response0 = await ws.ReceiveAsync(buffer, CancellationToken.None);
                if (Encoding.ASCII.GetString(buffer, 0, response0.Count).Contains("SERVER 2"))
                {
                    Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, response0.Count));
                    workflow = 3;
                }
                break;
            case 3: 
                // send RSA public key, retrieve AES keys from server
                Console.WriteLine("Press Key: Send public key");
                Console.ReadKey();
                await ws.SendAsync(Encoding.ASCII.GetBytes(rsaKeySet["Public"]), WebSocketMessageType.Text, true, CancellationToken.None);

                var response1 = await ws.ReceiveAsync(buffer, CancellationToken.None);
                if (Encoding.ASCII.GetString(buffer, 0, response1.Count).Contains("SERVER 4"))
                {
                    Console.WriteLine("Encrypted IV and  Key " + Encoding.ASCII.GetString(buffer, 0, response1.Count));
                    var serverResponse =  Encoding.ASCII.GetString(buffer, 0, response1.Count).Substring(9); //Encrypted IV and Key from server
                    var decrypted = rsaService.Create().Decrypt(rsaKeySet["Private"], Convert.FromBase64String(serverResponse)); // Decrypt AES Keys
                    Console.WriteLine("Decrypted IV and Key SERVER 4: " + decrypted);
                    var ivAndKey = decrypted.Split(";"); // splitting string iv and key
                    ivKey = ivAndKey[0];
                    aesKey = ivAndKey[1];
                    workflow = 5;
                }
                break;
            case 5: 
                // send AES encrypted message, and retrieve AES encrypted answer 
                Console.WriteLine("Press Key: Send encrypted AES content");
                Console.ReadKey();
                var aesEncryptedMessageToServer = aesService.Encrypt(new CyptographicSetup()
                {
                    Message = "Can you please give me the lottery numbers for the weekend?",
                    IV = ivKey,
                    Key = aesKey,
                    CipherMode = CipherMode.ECB,
                    PaddingMode = PaddingMode.PKCS7,
                });
                await ws.SendAsync(Encoding.ASCII.GetBytes("CLIENT 5: " + aesEncryptedMessageToServer), WebSocketMessageType.Text, true, CancellationToken.None);

                var response2 = await ws.ReceiveAsync(buffer, CancellationToken.None);
                if (Encoding.ASCII.GetString(buffer, 0, response2.Count).Contains("SERVER 6"))
                {
                    Console.WriteLine("Encrypted " + Encoding.ASCII.GetString(buffer, 0, response2.Count));
                    var aesDecryptedMessageFromServer = aesService.Decrypt(new CyptographicSetup()
                    {
                        Message = Encoding.ASCII.GetString(buffer, 0, response2.Count).Substring(9),
                        IV = ivKey,
                        Key = aesKey,
                        CipherMode = CipherMode.ECB,
                        PaddingMode = PaddingMode.PKCS7,
                    });
                    Console.WriteLine("Decrypted SERVER 6: "+aesDecryptedMessageFromServer);
                    workflow = 7;
                }
                break;
            case 7: 
                //send new AES encrypted message
                Console.WriteLine("Press Key: Send encrypted AES content");
                Console.ReadKey();
                var aesEncryptedReplyMessageToServer = aesService.Encrypt(new CyptographicSetup()
                {
                    Message = "Thank you, i will now play the lottery",
                    IV = ivKey,
                    Key = aesKey,
                    CipherMode = CipherMode.ECB,
                    PaddingMode = PaddingMode.PKCS7,
                });
                await ws.SendAsync(Encoding.ASCII.GetBytes("CLIENT 7: " + aesEncryptedReplyMessageToServer), WebSocketMessageType.Text, true, CancellationToken.None);

                var response3 = await ws.ReceiveAsync(buffer, CancellationToken.None);
                if (Encoding.ASCII.GetString(buffer, 0, response3.Count).Contains("SERVER 8"))
                {
                    Console.WriteLine("Encrypted" + Encoding.ASCII.GetString(buffer, 0, response3.Count));
                    var aesDecryptedMessageFromServer = aesService.Decrypt(new CyptographicSetup()
                    {
                        Message = Encoding.ASCII.GetString(buffer, 0, response3.Count).Substring(9),
                        IV = ivKey,
                        Key = aesKey,
                        CipherMode = CipherMode.ECB,
                        PaddingMode = PaddingMode.PKCS7,
                    });
                    Console.WriteLine("Decrypted SERVER: " + aesDecryptedMessageFromServer);
                    Console.WriteLine("Terminate connection");
                    Console.ReadKey();
                }
                break;
            default:
                Console.WriteLine("Close connection");
                break;
        }

    }
}