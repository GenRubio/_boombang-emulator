namespace boombang_emulator.src.Handlers.Scenery.Packets.RomanticInteractions
{
    internal class AcceptRomanticInteractionPacket
    {
        public static void Invoke(Models.User user, Models.User receiverUser, int interaction)
        {
            int userKeyInArea = user.Scenery!.GetClientIdentifier(user.Id);
            int receiverKeyInArea = receiverUser.Scenery!.GetClientIdentifier(receiverUser.Id);

            Models.ServerMessage serverMessage = new([137, 122]);
            serverMessage.AppendParameter(interaction);
            serverMessage.AppendParameter(receiverKeyInArea);
            serverMessage.AppendParameter(receiverUser.ActualPositionInScenery!.X);
            serverMessage.AppendParameter(receiverUser.ActualPositionInScenery!.Y);
            serverMessage.AppendParameter(userKeyInArea);
            serverMessage.AppendParameter(user.ActualPositionInScenery!.X);
            serverMessage.AppendParameter(user.ActualPositionInScenery!.Y);
            user.Scenery!.SendData(serverMessage);
        }
    }
}
