using System.Net.WebSockets;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace boombang_emulator.src.Controllers
{
    internal class SocketWebController
    {
        //https://developer.mozilla.org/en-US/docs/Web/API/WebSockets_API/Writing_WebSocket_server
        public static Dictionary<string, Models.PendingToken> tokensPending = [];
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
                HttpListenerContext httpListenerContext = await httpListener.GetContextAsync();
                if (httpListenerContext.Request.IsWebSocketRequest)
                {
                    await ReceiveData(httpListenerContext);
                }
                else
                {
                    httpListenerContext.Response.StatusCode = 400;
                    httpListenerContext.Response.Close();
                }
            }
        }
        private static async Task ReceiveData(HttpListenerContext context)
        {
            try
            {
                WebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
                WebSocket webSocket = webSocketContext.WebSocket;

                ArraySegment<byte> buffer = new(new byte[4096]);
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);

                string response = Encoding.UTF8.GetString(buffer.Array, buffer.Offset, result.Count);
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
                if (data == null)
                {
                    return;
                }
                Models.Client? client = SocketGameController.clients.Find(c => c.JwtToken == (string)data["jwt"]);
                HandlerWebController.SendHandler(webSocket, client, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static async void SendData(Models.Client client, string data)
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
            catch (Exception)
            {
                client.Close();
            }
        }
        private static async void RemovePendingTokens()
        {
            while(true)
            {
                //Console.WriteLine("Removing pending tokens: " + tokensPending.Count);
                foreach (var token in tokensPending)
                {
                    if (token.Value.TimeOut < DateTime.Now)
                    {
                        tokensPending.Remove(token.Value.Token);
                    }
                }
                await Task.Delay(1000);
            }
        }
    }
}
