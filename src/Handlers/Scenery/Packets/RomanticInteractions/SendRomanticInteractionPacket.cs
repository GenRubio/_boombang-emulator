using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets.RomanticInteractions
{
    internal class SendRomanticInteractionPacket
    {
        public static void Invoke(Models.Client client, int interaction, int receiverId)
        {
            Models.Scenarios.Scenery scenery = client.User!.Scenery!;
            int userKeyInArea = scenery.GetClientIdentifier(client.User.Id);

            Models.Client? receiver = scenery.Clients[receiverId] ?? throw new Exception("Receiver not found");

            ServerMessage serverMessage = new([137, 120]);
            serverMessage.AppendParameter(interaction);
            serverMessage.AppendParameter(userKeyInArea);
            receiver.SendData(serverMessage);
        }
    }
}
