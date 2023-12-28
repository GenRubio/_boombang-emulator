using System.Collections.Concurrent;

namespace boombang_emulator.src.Controllers
{
    delegate void ProcessHandler(Models.Client client, Models.ClientMessage clientMessage);
    internal class HandlerController
    {
        private static ConcurrentDictionary<int, ProcessHandler> handlers = [];
        public static void Invoke()
        {
            InvokeHandlers();
        }
        private static void InvokeHandlers()
        {
            Handlers.PingHandler.Invoke();
            Handlers.Auth.LoginHandler.Invoke();
            Handlers.BPad.BPadFriendsHandler.Invoke();
            Handlers.BPad.BPadMessagesHandler.Invoke();
            Handlers.Catalog.CatalogHandler.Invoke();
            Handlers.Backpack.BackpackUserHandler.Invoke();
            Handlers.House.UserHouseButtonHandler.Invoke();
            Handlers.FlowerPower.MenuHandler.Invoke();
            Handlers.UndefinedHandlers.Invoke();
            Handlers.Scenery.GoOutHandler.Invoke();
            Handlers.Scenery.VotesHandler.Invoke();
            Handlers.Scenery.WalkHandler.Invoke();
            Handlers.Scenery.WatchHandler.Invoke();
        }
        public static void SetHandler(int header, ProcessHandler handler)
        {
            handlers.TryAdd(header, handler);
        }
        public static void SendHandler(Models.Client client, Models.ClientMessage clientMessage)
        {
            if (client.GetSocket().Connected && clientMessage != null)
            {
                if (!handlers.ContainsKey(clientMessage.GetInteger()))
                {
                    Console.WriteLine("Falta: " + clientMessage.GetInteger() + " -> " + clientMessage.GetData());
                }
                else
                {
                    try
                    {
                        handlers[clientMessage.GetInteger()](client, clientMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        client.Close();
                    }
                }
            }
        }
    }
}
