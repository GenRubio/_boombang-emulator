﻿using boombang_emulator.src.Utils;
using System.Net;
using System.Net.WebSockets;
using System.Text;

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
            WebSocketContext? webSocketContext = null;
            try
            {
                webSocketContext = await context.AcceptWebSocketAsync(null);
                WebSocket webSocket = webSocketContext.WebSocket;

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
                            Models.Client? client = SocketGameController.clients.Find(c => c.JwtToken == (string)data["jwt"]);
                            HandlerWebController.SendHandler(webSocket, client, data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
                webSocketContext?.WebSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, "An error occurred", CancellationToken.None).Wait();
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
        public static async void SendDataAll(string data)
        {
            foreach (Models.Client client in SocketGameController.clients)
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
        }
        private static async void RemovePendingTokens()
        {
            while (true)
            {
                //Console.WriteLine("Removing pending tokens: " + tokensPending.Count);
                foreach (var token in tokensPending.Values.ToList())
                {
                    if (token.TimeOut < DateTime.Now)
                    {
                        tokensPending.Remove(token.Token);
                    }
                }
                await Task.Delay(1000);
            }
        }
    }
}
