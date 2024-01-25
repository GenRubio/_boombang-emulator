using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class WatchPacket
    {
        public static void Invoke(Models.User user, int z)
        {
            int userKeyInArea = user.Scenery!.GetClientIdentifier(user.Id);

            ServerMessage serverMessage = new([135]);
            serverMessage.AppendParameter(userKeyInArea);
            serverMessage.AppendParameter(user.ActualPositionInScenery!.X);
            serverMessage.AppendParameter(user.ActualPositionInScenery!.Y);
            serverMessage.AppendParameter(z);
            user.Scenery.SendData(serverMessage);
        }
    }
}
