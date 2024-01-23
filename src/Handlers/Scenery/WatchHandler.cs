﻿using boombang_emulator.src.Controllers;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Handlers.Scenery.Packets;
using boombang_emulator.src.Models;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Handlers.Scenery
{
    internal class WatchHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(135, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                bool isBlockedAction = client.User!.Actions.Watch;
                if (isBlockedAction)
                {
                    return;
                }

                int z = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                WatchPacket.Invoke(client, z);

                client.User!.ActualPositionInScenery!.Z = z;
                client.User.Actions.SetAction(AvatarActionsEnum.WATCH, client.User.Avatar.Id);
            }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
                client.Close();
            }
        }
    }
}
