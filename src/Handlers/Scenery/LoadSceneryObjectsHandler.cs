﻿using boombang_emulator.src.Controllers;
using boombang_emulator.src.Exceptions;
using boombang_emulator.src.Handlers.Scenery.Packets;
using boombang_emulator.src.HandlersWeb.FlowerPower.Packets;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;
using boombang_emulator.src.Utils;
namespace boombang_emulator.src.Handlers.Scenery
{
    internal class LoadSceneryObjectsHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(128121, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                switch (client.User!.Scenery!.TypeId)
                {
                    case 1:
                        LoadAreaObjectsPacket.Invoke(client);
                        LoadAreaConfigPacket.Invoke(client);
                        break;
                }
                UserInSceneryPacketWeb.Invoke(client);
            }
            catch (MiddlewareException) { }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
                client.Close();
            }
        }
    }
}
