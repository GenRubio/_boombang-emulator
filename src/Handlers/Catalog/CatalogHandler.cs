using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.Catalog.Packets;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers.Catalog
{
    internal class CatalogHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(189133, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            CatalogPacket.Invoke(client);
        }
    }
}
