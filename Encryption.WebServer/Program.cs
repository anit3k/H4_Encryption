using System.Net;
using System.Net.WebSockets;
using System.Text;

Console.Title = "Server";
var builder = WebApplication.CreateBuilder();
builder.WebHost.UseUrls("http://localhost:6666");
var app = builder.Build();
app.UseWebSockets();
app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var buffer = new byte[256];
        int workflow = 2;
        using (var webSocket = await context.WebSockets.AcceptWebSocketAsync())
        {
            while (true)
            {
                var response0 = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                switch (workflow)
                {
                    case 2:
                        if (Encoding.ASCII.GetString(buffer, 0, response0.Count).Contains("CLIENT 1"))
                        {
                            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, response0.Count));

                            await webSocket.SendAsync(Encoding.ASCII.GetBytes($"SERVER 2: Hello Client, send public RSA key"), WebSocketMessageType.Text, true, CancellationToken.None);
                            Console.WriteLine("SERVER 2: Hello Client, send public RSA key");
                            workflow = 4;
                        }
                        break;
                    case 4:
                        if (Encoding.ASCII.GetString(buffer, 0, response0.Count).Contains("CLIENT 3"))
                        {
                            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, response0.Count));

                            await webSocket.SendAsync(Encoding.ASCII.GetBytes($"SERVER 4: Sending AES IV and Key"), WebSocketMessageType.Text, true, CancellationToken.None);
                            Console.WriteLine("SERVER 4: Sending AES IV and Key");
                            workflow = 6;
                        }
                        break;
                    case 6:
                        if (Encoding.ASCII.GetString(buffer, 0, response0.Count).Contains("CLIENT 5"))
                        {
                            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, response0.Count));

                            await webSocket.SendAsync(Encoding.ASCII.GetBytes($"SERVER 6: Sending AES IV and Key"), WebSocketMessageType.Text, true, CancellationToken.None);
                            Console.WriteLine("SERVER 6: Sending AES IV and Key");

                            workflow = 8;
                        }
                        break;
                    case 8:
                        if (Encoding.ASCII.GetString(buffer, 0, response0.Count).Contains("CLIENT 7"))
                        {
                            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, response0.Count));

                            await webSocket.SendAsync(Encoding.ASCII.GetBytes($"SERVER 8: Sending AES IV and Key"), WebSocketMessageType.Text, true, CancellationToken.None);
                            Console.WriteLine("SERVER 8: Sending AES IV and Key");
                            
                        }
                        break;
                    default:
                        Console.WriteLine("Default case: ERROR");
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