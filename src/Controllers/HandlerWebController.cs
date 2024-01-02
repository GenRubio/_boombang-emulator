using boombang_emulator.src.HandlersWeb;
using boombang_emulator.src.HandlersWeb.Auth;
using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace boombang_emulator.src.Controllers
{
    delegate void ProcessWebHandler(WebSocket webSocket, Models.Client? client, Dictionary<string, object> data);
    internal class HandlerWebController
    {
        private static ConcurrentDictionary<string, ProcessWebHandler> handlers = [];
        public static void Invoke()
        {
            SetWebSocketHandlerWeb.Invoke();
            GoToAreaHandlerWeb.Invoke();
        }
        public static void SetHandler(string header, ProcessWebHandler handler)
        {
            handlers.TryAdd(header, handler);
        }
        public static void SendHandler(WebSocket webSocket, Models.Client? client, Dictionary<string, object> data)
        {
            handlers[(string)data["key"]](webSocket, client, data);
        }
    }
}
