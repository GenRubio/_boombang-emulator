using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class RemoveCoconutPacket
    {
        public static void Invoke(Models.User user, int coconutId)
        {
            ServerMessage serverMessage = new([184, 121]);
            serverMessage.AppendParameter(user.Id);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(coconutId);
            user.Scenery!.SendData(serverMessage);
        }
    }
}
