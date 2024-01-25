using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class PublicChatPacket
    {
        public static void Invoke(Models.User user, string message)
        {
            int userKeyInArea = user.Scenery!.GetClientIdentifier(user.Id);

            ServerMessage serverMessage = new([186]);
            serverMessage.AppendParameter(userKeyInArea);
            serverMessage.AppendParameter(message);
            serverMessage.AppendParameter((int)Enums.ColorChatsEnum.NORMAL);
            user.Scenery.SendData(serverMessage);
        }
    }
}
