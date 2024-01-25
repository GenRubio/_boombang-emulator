using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class ExpressionPacket
    {
        public static void Invoke(Models.Client client, int expressionId)
        {
            ServerMessage serverMessage = new([134]);
            serverMessage.AppendParameter(expressionId);
            serverMessage.AppendParameter(client.User!.Id);
            client.User!.Scenery!.SendData(serverMessage);
        }
    }
}
