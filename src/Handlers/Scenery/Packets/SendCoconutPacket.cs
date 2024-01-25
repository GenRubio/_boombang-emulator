using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class SendCoconutPacket
    {
        public static void Invoke(Models.Client client, int coconutId)
        {
            ServerMessage serverMessage = new([184, 120]);
            serverMessage.AppendParameter(client.User!.Id);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(coconutId);
            client.User!.Scenery!.SendData(serverMessage);
        }
    }
}
