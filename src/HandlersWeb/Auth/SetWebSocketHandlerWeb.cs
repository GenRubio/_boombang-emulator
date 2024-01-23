using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;
using boombang_emulator.src.Utils;
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
                if (client == null && data != null)
                {
                    string token = (string)data["jwt"];
                    SocketWebController.tokensPending.TryRemove(token, out _);
                    SocketWebController.tokensPending.TryAdd(token, new PendingToken(token, webSocket));
                }
            }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
            }
        }
    }
}
