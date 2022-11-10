using System.Net.WebSockets;
using System.Net;
using System.Text;
using System;

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
        using (var webSocket = await context.WebSockets.AcceptWebSocketAsync())
        {
            while (true)
            {
                await webSocket.SendAsync(Encoding.ASCII.GetBytes($"Test - {DateTime.Now} To Clinet --> From Server"), WebSocketMessageType.Text, true, CancellationToken.None);
                await Task.Delay(1000);
                var result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, result.Count));
            }
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});
await app.RunAsync();