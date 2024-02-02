using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class LoadAreaConfigPacket
    {
        public static void Invoke(Models.Client client)
        {
            ServerMessage serverMessage = new([175]);
            serverMessage.AppendParameter([1, 0, 0]);
            serverMessage.AppendParameter([2, 0, 0]);
            serverMessage.AppendParameter([3, 0, 0]);
            serverMessage.AppendParameter([4, 250, 0]);
            serverMessage.AppendParameter([5, 25, 0]);
            client.SendData(serverMessage);
        }
    }
}
