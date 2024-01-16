namespace boombang_emulator.src.Handlers.Scenery.Packets.RomanticInteractions
{
    internal class SendRomanticInteractionPacket
    {
        public static void Invoke(Models.Client client, int interaction, int receiverId)
        {
            int userKeyInArea = client.User!.Scenery!.GetClientIdentifier(client.User.Id);

            Models.Client? receiver = client.User.Scenery!.GetClientById(receiverId) ?? throw new Exception("Receiver not found");

            Models.ServerMessage serverMessage = new([137, 120]);
            serverMessage.AppendParameter(interaction);
            serverMessage.AppendParameter(userKeyInArea);
            receiver.SendData(serverMessage);
        }
    }
}
