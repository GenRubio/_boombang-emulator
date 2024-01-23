using boombang_emulator.src.Enums;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class WalkPacket
    {
        public static void Invoke(Models.User user, int userKeyInArea)
        {
            Models.ServerMessage serverMessage = new([182]);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(userKeyInArea);
            serverMessage.AppendParameter(user.ActualPositionInScenery!.X);
            serverMessage.AppendParameter(user.ActualPositionInScenery!.Y);
            serverMessage.AppendParameter(user.ActualPositionInScenery!.Z);
            serverMessage.AppendParameter(Convert.ToInt32(WalkEnum.PACKET));
            serverMessage.AppendParameter(user.WalkTrajectory!.Positions.Count >= 1 ? 1 : 0);
            user.Scenery!.SendData(serverMessage);
        }
    }
}
