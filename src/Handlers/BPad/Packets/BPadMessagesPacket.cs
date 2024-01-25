using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.BPad.Packets
{
    internal class BPadMessagesPacket
    {
        public static void Invoke(Client client)
        {
            ServerMessage serverMessage = new([132, 121]);
            serverMessage.AppendParameter(0);
            client.SendData(serverMessage);
        }
    }
}
