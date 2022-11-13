using Encryption.Asymmetric.Factories;
using Encryption.Symmetric.Algorithms;
using Encryption.Symmetric.Factories;
using Encryption.Symmetric.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System.Security.Cryptography;

namespace Encryption.MauiSecureChatApp;

public partial class ChatPage : ContentPage
{
    private readonly HubConnection _hubConnection;
    private readonly IRSAFactory _rsaService;
    private readonly CyptographicSetup _aesContainer;
    private readonly IAlgortihm _aesService;
    private string _privatRSAKey;
    private string _publicRSAKey;
    private static string _messages;

    public ChatPage(IRSAFactory rsaFactory, ISymmetricFactory aesService, ICryptographicSetupFactory aesContainer)
    {
        InitializeComponent();

        // build SignalR connection
        _hubConnection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5181/chatHub")
            .Build();

        // "observers" methods from signalR hub
        _hubConnection.On<string, string>("MessageReceived", async (user, message) =>
        {
            await Task.Run(async () => await DecryptMessageFromServer(user, message));
        });

        _hubConnection.On<string>("EncryptedAesKey", async (keys) =>
        {
            await Task.Run(async () => await DecryptAESKeyset(keys));
            chatMessages.Text = _messages;
        });

        // Thread to run hub connection
        Task.Run(() =>
        {
            Dispatcher.Dispatch(async () =>
            await _hubConnection.StartAsync());
        });


        _rsaService = rsaFactory;
        _aesContainer = aesContainer.Create();
        _aesContainer.CipherMode = CipherMode.ECB;
        _aesContainer.PaddingMode = PaddingMode.PKCS7;
        _aesService = aesService.CreateAlgortihm("AES");
        GenerateRsaKey();
    }

    /// <summary>
    /// Generate RSA Algorithm Key set
    /// </summary>
    private void GenerateRsaKey()
    {
        var key = _rsaService.Create().GenerateNewKeySet();
        _privatRSAKey = key["Private"];
        _publicRSAKey = key["Public"];
    }

    /// <summary>
    /// Button to send RSA public key to SignalR hub
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void sendPublicKeyBtn_Clicked(object sender, EventArgs e)
    {
        await SendPublicKeyToHub(_publicRSAKey);
    }

    /// <summary>
    /// Button to send encrypted message to hub
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void sendChatBtn_Clicked(object sender, EventArgs e)
    {
        _aesContainer.Message = userMessage.Text;
        var encrypted = _aesService.Encrypt(_aesContainer);

        await _hubConnection.InvokeAsync("SendEncryptedMessage",
            arg1: userName.Text, arg2: encrypted);

        userMessage.Text = String.Empty;
        chatMessages.Text = _messages;
    }

    /// <summary>
    /// Decrypt message from server with the AES Keys received
    /// </summary>
    /// <param name="user">string of user name</param>
    /// <param name="message">message to be decrypted</param>
    private async  Task DecryptMessageFromServer(string user, string message)
    {
        _aesContainer.Message = message;
        var decrypted = _aesService.Decrypt(_aesContainer);
        _messages += Environment.NewLine +decrypted;        
    }

    /// <summary>
    /// Task to send users RSA public key to server/hub
    /// </summary>
    /// <param name="publicKey">RSA public key in XML format</param>
    private async Task SendPublicKeyToHub(string publicKey)
    {
        _messages += Environment.NewLine + "System: public key send to server.";
        chatMessages.Text = _messages;
        await _hubConnection.InvokeCoreAsync("ReceivePublicRSAKey", args: new[] { publicKey });
    }

    /// <summary>
    /// Task to decrypt and ad key set to AES setup container
    /// </summary>
    /// <param name="encryptedKeys">encrypted message from hub with AES keys</param>
    private async Task DecryptAESKeyset(string encryptedKeys)
    {
        var decrypted = _rsaService.Create().Decrypt(_privatRSAKey, Convert.FromBase64String(encryptedKeys));

        var temp = decrypted.Split(";");
        _aesContainer.IV = temp[0];
        _aesContainer.Key = temp[1];
    }
}