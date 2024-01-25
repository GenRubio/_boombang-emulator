using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets.RomanticInteractions
{
    internal class DeclineRomanticInteractionPacket
    {
        public static void Invoke(Models.Client client, int userKeyInArea)
        {
            ServerMessage serverMessage = new([137, 123]);
            serverMessage.AppendParameter(userKeyInArea);
            client.SendData(serverMessage);
        }
    }
}
