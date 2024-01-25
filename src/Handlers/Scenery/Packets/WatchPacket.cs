using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class WatchPacket
    {
        public static void Invoke(Models.Client client, int z)
        {
            int userKeyInArea = client.User!.Scenery!.GetClientIdentifier(client.User.Id);

            ServerMessage serverMessage = new([135]);
            serverMessage.AppendParameter(userKeyInArea);
            serverMessage.AppendParameter(client.User!.ActualPositionInScenery!.X);
            serverMessage.AppendParameter(client.User!.ActualPositionInScenery!.Y);
            serverMessage.AppendParameter(z);
            client.User.Scenery.SendData(serverMessage);
        }
    }
}
