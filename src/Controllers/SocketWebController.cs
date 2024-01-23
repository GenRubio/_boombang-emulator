using boombang_emulator.src.Utils;
using System.Collections.Concurrent;
using System.Net;
using System.Net.WebSockets;
using System.Text;

namespace boombang_emulator.src.Controllers
{
    internal class SocketWebController
    {
        public static ConcurrentDictionary<string, Models.PendingToken> tokensPending = [];
        public static void Invoke()
        {
            HttpListener httpListener = new();
            httpListener.Prefixes.Add(Config.webSocketRoute);
            httpListener.Start();
            Console.WriteLine($"Listening WebSocket on {Config.webSocketRoute}");

            ProcessData(httpListener);
            RemovePendingTokens();
        }
        private static async void ProcessData(HttpListener httpListener)
        {
            while (true)
            {
                try
                {
                    HttpListenerContext httpListenerContext = await httpListener.GetContextAsync();
                    if (httpListenerContext.Request.IsWebSocketRequest)
                    {
                        //await ReceiveData(httpListenerContext);
                        Task.Run(() => ReceiveData(httpListenerContext));
                    }
                    else
                    {
                        httpListenerContext.Response.StatusCode = 400;
                        httpListenerContext.Response.Close();
                    }
                }
                catch (Exception ex)
                {
                    ConsoleUtils.WriteError(ex);
                }
            }
        }
        private static async Task ReceiveData(HttpListenerContext context)
        {
            WebSocketContext? webSocketContext = null;
            webSocketContext = await context.AcceptWebSocketAsync(null);
            WebSocket webSocket = webSocketContext.WebSocket;
            try
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    ArraySegment<byte> buffer = new(new byte[4096]);
                    WebSocketReceiveResult result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    }
                    else
                    {
                        string response = Encoding.UTF8.GetString(buffer.Array, buffer.Offset, result.Count);
                        var data = JsonUtils.Deserialize(response);
                        if (data != null)
                        {
                            Models.Client? client = SocketGameController.clients.Values.FirstOrDefault(c => c.JwtToken == (string)data["jwt"]);
                            HandlerWebController.SendHandler(webSocket, client, data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
                if (webSocket.State == WebSocketState.Open)
                {
                    webSocketContext?.WebSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, "An error occurred", CancellationToken.None).Wait();
                }
            }
        }
        public static async void SendData(string data, Models.Client? client)
        {
            if (client != null)
            {
                try
                {
                    WebSocket clientSocket = client.WebSocket;
                    if (clientSocket != null && clientSocket.State == WebSocketState.Open)
                    {
                        byte[] messageBytes = Encoding.UTF8.GetBytes(data);
                        await clientSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
                catch (Exception ex)
                {
                    ConsoleUtils.WriteError(ex);
                    client.Close();
                }
            }
            else
            {
                foreach (Models.Client connectedClient in SocketGameController.clients.Values)
                {
                    try
                    {
                        WebSocket clientSocket = connectedClient.WebSocket;
                        if (clientSocket != null && clientSocket.State == WebSocketState.Open)
                        {
                            byte[] messageBytes = Encoding.UTF8.GetBytes(data);
                            await clientSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
                        }
                    }
                    catch (Exception ex)
                    {
                        ConsoleUtils.WriteError(ex);
                        connectedClient.Close();
                    }
                }
            }
        }
        private static async void RemovePendingTokens()
        {
            while (true)
            {
                var currentDateTime = DateTime.Now;
                var tokensToRemove = tokensPending.Where(kv => kv.Value.TimeOut < currentDateTime).Select(kv => kv.Key);

                foreach (var tokenKey in tokensToRemove)
                {
                    tokensPending.TryRemove(tokenKey, out var removedToken);
                }
                await Task.Delay(1000);
            }
        }
    }
}
