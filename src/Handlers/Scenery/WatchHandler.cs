using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.Scenery.Packets;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers.Scenery
{
    internal class WatchHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(135, new ProcessHandler(Watch));
        }
        private static void Watch(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                if (Middlewares.BlockAction(client, Enums.BlockActionEnum.WATCH))
                {
                    return;
                }

                if (
                client.User == null
                || client.User.Scenery == null
                || client.User.ActualPositionInScenery == null
               )
                {
                    throw new Exception("-");
                }

                int z = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                WatchPacket.Invoke(client, z);
                client.User.ActualPositionInScenery.Z = z;
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
