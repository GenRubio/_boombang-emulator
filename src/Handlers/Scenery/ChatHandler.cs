using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.Scenery.Packets;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers.Scenery
{
    internal class ChatHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(186, new ProcessHandler(PublicChat));
        }
        private static void PublicChat(Client client, ClientMessage clientMessage)
        {
            try
            {
                if (client.User == null || client.User.Scenery == null)
                {
                    throw new Exception("-");
                }

                string message = clientMessage.Parameters[1, 0];
                if (Middlewares.BlockAction(client, Enums.BlockActionEnum.Chat))
                {
                    return;
                }

                PublicChatPacket.Invoke(client, message);
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
