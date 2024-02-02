using boombang_emulator.src.Models.Messages;
using boombang_emulator.src.Utils;
using System.Collections.Concurrent;

namespace boombang_emulator.src.Controllers
{
    delegate void ProcessHandler(Models.Client client, ClientMessage clientMessage);
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
            Handlers.FlowerPower.LoadSceneriesHandler.Invoke();
            Handlers.Scenery.LoadSceneryObjectsHandler.Invoke();
            Handlers.UndefinedHandlers.Invoke();
            Handlers.Scenery.GoOutHandler.Invoke();
            Handlers.Scenery.VotesHandler.Invoke();
            Handlers.Scenery.WalkHandler.Invoke();
            Handlers.Scenery.WatchHandler.Invoke();
            Handlers.Scenery.ExpressionHandler.Invoke();
            Handlers.Scenery.ChatHandler.Invoke();
            Handlers.Scenery.RomanticInteractions.SendRomanticInteractionHandler.Invoke();
            Handlers.Scenery.RomanticInteractions.AcceptRomanticInteractionHandler.Invoke();
            Handlers.Scenery.RomanticInteractions.CancelRomanticInteractionHandler.Invoke();
            Handlers.Scenery.Coconut.SendCoconutHandler.Invoke();
            Handlers.Scenery.Coconut.ChangeCoconutHandler.Invoke();
            Handlers.Scenery.Uppercut.SendUppercutHandler.Invoke();
        }
        public static void SetHandler(int header, ProcessHandler handler)
        {
            handlers.TryAdd(header, handler);
        }
        public static void SendHandler(Models.Client client, ClientMessage clientMessage)
        {
            if (client.GetSocket().Connected && clientMessage != null)
            {
                if (!handlers.ContainsKey(clientMessage.GetInteger()))
                {
                    if (Config.debugPackets)
                    {
                        Console.WriteLine("Falta: " + clientMessage.GetInteger() + " -> " + clientMessage.GetData());
                    }
                }
                else
                {
                    try
                    {
                        handlers[clientMessage.GetInteger()](client, clientMessage);
                    }
                    catch (Exception ex)
                    {
                        ConsoleUtils.WriteError(ex);
                        client.Close();
                    }
                }
            }
        }
    }
}
