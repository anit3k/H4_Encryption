using System.Net.WebSockets;
using System.Text;

Console.Title = "Client";
using (var ws = new ClientWebSocket())
{
    await ws.ConnectAsync(new Uri("ws://localhost:6666/ws"), CancellationToken.None);
    var buffer = new byte[256];
    while (ws.State == WebSocketState.Open)
    {
        var result = await ws.ReceiveAsync(buffer, CancellationToken.None);
        Console.ReadKey();
        await ws.SendAsync(Encoding.ASCII.GetBytes($"Test - {DateTime.Now} From Client --> To Server"), WebSocketMessageType.Text, true, CancellationToken.None);
        if (result.MessageType == WebSocketMessageType.Close)
        {
            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
        }
        else
        {
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, result.Count));
        }
        await ws.SendAsync(Encoding.ASCII.GetBytes($"Hey Server"), WebSocketMessageType.Text, true, CancellationToken.None);
    }
}