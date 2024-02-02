using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets.Uppercut
{
    internal class SendUppercutPacket
    {
        public static void Invoke(Models.User user, Models.User receiverUser)
        {
            int userKeyInArea = user.Scenery!.GetClientIdentifier(user.Id);
            int receiverKeyInArea = receiverUser.Scenery!.GetClientIdentifier(receiverUser.Id);
            ServerMessage serverMessage = new([145]);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(userKeyInArea);
            serverMessage.AppendParameter(user.ActualPositionInScenery!.X);
            serverMessage.AppendParameter(user.ActualPositionInScenery!.Y);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(receiverKeyInArea);
            serverMessage.AppendParameter(receiverUser.ActualPositionInScenery!.X);
            serverMessage.AppendParameter(receiverUser.ActualPositionInScenery!.Y);
            user.Scenery!.SendData(serverMessage);
        }
    }
}
