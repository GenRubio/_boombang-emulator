using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class PublicChatPacket
    {
        public static void Invoke(Models.Client client, string message)
        {
            int userKeyInArea = client.User!.Scenery!.GetClientIdentifier(client.User.Id);

            ServerMessage serverMessage = new([186]);
            serverMessage.AppendParameter(userKeyInArea);
            serverMessage.AppendParameter(message);
            serverMessage.AppendParameter((int)Enums.ColorChatsEnum.NORMAL);
            client.User.Scenery.SendData(serverMessage);
        }
    }
}
