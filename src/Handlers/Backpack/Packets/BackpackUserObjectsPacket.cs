using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Backpack.Packets
{
    internal class BackpackUserObjectsPacket
    {
        public static void Invoke(Client client)
        {
            ServerMessage serverMessage = new([189, 180]);
            client.SendData(serverMessage);
        }
    }
}
