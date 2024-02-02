using boombang_emulator.src.Controllers;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Exceptions;
using boombang_emulator.src.Handlers.Scenery.Packets;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;
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

                bool isBlockedAction = client.User!.Actions.Action.Watch;
                if (isBlockedAction)
                {
                    return;
                }

                int z = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                WatchPacket.Invoke(client.User, z);

                client.User!.ActualPositionInScenery!.Z = z;
                client.User.Actions.GenericAction.SetAction(AvatarActionsEnum.WATCH);
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
