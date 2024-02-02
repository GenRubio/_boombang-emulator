using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets.Coconut
{
    internal class ChangeCoconutPacket
    {
        public static void Invoke(Models.User user, int coconutId)
        {
            ServerMessage serverMessage = new([131]);
            serverMessage.AppendParameter(user.Id);
            serverMessage.AppendParameter(coconutId);
            user.Scenery!.SendData(serverMessage);
        }
    }
}
