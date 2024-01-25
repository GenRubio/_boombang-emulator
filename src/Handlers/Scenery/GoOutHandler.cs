﻿using boombang_emulator.src.Controllers;
using boombang_emulator.src.HandlersWeb.FlowerPower.Packets;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Handlers.Scenery
{
    internal class GoOutHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(128124, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                int userKeyInArea = client.User!.Scenery!.GetClientIdentifier(client.User.Id);
                client.User.Scenery.SendData(new([128, 123], [userKeyInArea]));
                client.User.Scenery.RemoveClient(client);
                client.SendData(new([128, 124]));

                RenderAreasPacketWeb.Invoke(client);
                RenderAreasCountUserPacketWeb.Invoke(null);
            }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
                client.Close();
            }
        }
    }
}
