using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers.BPad.Packets
{
    internal class BPadFriendsPacket
    {
        public static void Invoke(Client client)
        {
            ServerMessage serverMessage = new([132, 120]);
            serverMessage.AppendParameter(0);
            client.SendData(serverMessage);
        }
    }
}
