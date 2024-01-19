using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.Backpack.Packets;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers.Backpack
{
    internal class BackpackUserHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(189180, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            BackpackUserObjectsPacket.Invoke(client);
        }
    }
}
