using System.Net.WebSockets;
using System.Text;

Console.Title = "Client";
using (var ws = new ClientWebSocket())
{
    await ws.ConnectAsync(new Uri("ws://localhost:6666/ws"), CancellationToken.None);
    var buffer = new byte[256];
    int workflow = 1;
    string fromClientText = "";
    while (ws.State == WebSocketState.Open)
    {
        switch (workflow)
        {
            case 1:
                Console.WriteLine("Press Key: Hey Server");
                Console.ReadKey();

                await ws.SendAsync(Encoding.ASCII.GetBytes($"CLIENT 1: Hey Server"), WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine("CLIENT 1: Hey Server");

                var response0 = await ws.ReceiveAsync(buffer, CancellationToken.None);
                if (Encoding.ASCII.GetString(buffer, 0, response0.Count).Contains("SERVER 2"))
                {
                    Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, response0.Count));
                    workflow = 3;
                }
                break;
            case 3:
                Console.WriteLine("Press Key: Send public key");
                Console.ReadKey();

                await ws.SendAsync(Encoding.ASCII.GetBytes($"CLIENT 3: Sending public key <<RSA Key>>"), WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine("CLIENT 3: Sending public key <<RSA Key>>");

                var response1 = await ws.ReceiveAsync(buffer, CancellationToken.None);
                if (Encoding.ASCII.GetString(buffer, 0, response1.Count).Contains("SERVER 4"))
                {
                    Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, response1.Count));
                    workflow = 5;
                }
                break;
            case 5:
                Console.WriteLine("Press Key: Send encryptet AES content");
                Console.ReadKey();

                await ws.SendAsync(Encoding.ASCII.GetBytes($"CLIENT 5: <<AES Content>>"), WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine("CLIENT 5: <<AES Content>>");

                var response2 = await ws.ReceiveAsync(buffer, CancellationToken.None);
                if (Encoding.ASCII.GetString(buffer, 0, response2.Count).Contains("SERVER 6"))
                {
                    Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, response2.Count));
                    workflow = 7;
                }
                break;
            case 7:
                Console.WriteLine("Press Key: Send encryptet AES content");
                Console.ReadKey();

                await ws.SendAsync(Encoding.ASCII.GetBytes($"CLIENT 7: <<AES Content>>"), WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine("CLIENT 7: <<AES Content>>");

                var response3 = await ws.ReceiveAsync(buffer, CancellationToken.None);
                if (Encoding.ASCII.GetString(buffer, 0, response3.Count).Contains("SERVER 8"))
                {
                    Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, response3.Count));
                }
                break;

            default:
                Console.WriteLine("Default case: ERROR");
                break;
        }

        //await ws.SendAsync(Encoding.ASCII.GetBytes($"Test - {DateTime.Now} From Client --> To Server"), WebSocketMessageType.Text, true, CancellationToken.None);
        //if (response.MessageType == WebSocketMessageType.Close)
        //{
        //    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
        //}
        //else
        //{
        //    //Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, result.Count));
        //}
    }
}