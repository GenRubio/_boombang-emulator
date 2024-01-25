using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets.RomanticInteractions
{
    internal class AcceptRomanticInteractionPacket
    {
        public static void Invoke(Models.User user, Models.User senderUser, int interaction)
        {
            int userKeyInArea = user.Scenery!.GetClientIdentifier(user.Id);
            int senderKeyInArea = senderUser.Scenery!.GetClientIdentifier(senderUser.Id);

            ServerMessage serverMessage = new([137, 122]);
            serverMessage.AppendParameter(interaction);
            serverMessage.AppendParameter(senderKeyInArea);
            serverMessage.AppendParameter(senderUser.ActualPositionInScenery!.X);
            serverMessage.AppendParameter(senderUser.ActualPositionInScenery!.Y);
            serverMessage.AppendParameter(userKeyInArea);
            serverMessage.AppendParameter(user.ActualPositionInScenery!.X);
            serverMessage.AppendParameter(user.ActualPositionInScenery!.Y);
            user.Scenery!.SendData(serverMessage);
        }
    }
}
