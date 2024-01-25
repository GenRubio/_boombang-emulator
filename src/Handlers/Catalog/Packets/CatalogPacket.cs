using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Catalog.Packets
{
    internal class CatalogPacket
    {
        public static void Invoke(Client client)
        {
            ServerMessage serverMessage = new([189, 133]);
            serverMessage.AppendParameter(0);
            client.SendData(serverMessage);
        }
    }
}
