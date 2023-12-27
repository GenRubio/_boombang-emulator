using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;
using System.Net.WebSockets;

namespace boombang_emulator.src.HandlersWeb.Auth
{
    internal class SetWebSocketHandlerWeb
    {
        public static void Invoke()
        {
            HandlerWebController.SetHandler("set-websocket-user", new ProcessWebHandler(SetWebSocket));
        }
        private static void SetWebSocket(WebSocket webSocket, Client? client, Dictionary<string, object> data)
        {
            try
            {
                if (client == null)
                {
                    if (data == null)
                    {
                        return;
                    }
                    string token = (string)data["jwt"];
                    if (!SocketWebController.tokensPending.ContainsKey(token))
                    {
                        SocketWebController.tokensPending.Add(token, new PendingToken(token, webSocket));
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
