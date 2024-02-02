using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class LoadUsersInAreaPacket
    {
        public static ServerMessage Invoke(ServerMessage serverMessage, Models.Scenarios.Scenery scenery)
        {
            foreach (var item in scenery.Clients)
            {
                if (
                    item.Value.User != null
                    && item.Value.User.Scenery != null
                    && item.Value.User.ActualPositionInScenery != null
                   )
                {
                    var user = item.Value.User;
                    serverMessage.AppendParameter(scenery.GetClientIdentifier(user.Id));
                    serverMessage.AppendParameter(user.Username);
                    serverMessage.AppendParameter(user.Avatar.Id);
                    serverMessage.AppendParameter(user.Avatar.Color);
                    serverMessage.AppendParameter(user.ActualPositionInScenery.X);
                    serverMessage.AppendParameter(user.ActualPositionInScenery.Y);
                    serverMessage.AppendParameter(user.ActualPositionInScenery.Z);
                    serverMessage.AppendParameter("BurBian");
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(Convert.ToString(0) + "³15³16³17");
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(new object[] { 0, 0, 0, 0, 0 });
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(user.Avatar.SelectedCoconut);
                    serverMessage.AppendParameter(user.Avatar.CoconutLevel);
                    serverMessage.AppendParameter(new object[] { "Hola", "Hola", "Hola" });
                    serverMessage.AppendParameter(new object[] { "Hola", "Hola", "Hola" });
                    serverMessage.AppendParameter(new object[] { 50, 50, 50 });
                    serverMessage.AppendParameter("Hola");
                    serverMessage.AppendParameter(new object[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, "0³" + 1 + "³0³0³0³" + 1 + "³0³0³" + user.Avatar.CoconutLevel + "³" + user.Avatar.CoconutPoints + "³0³" + user.Avatar.CoconutFinishLevelPoints + "³" + 1 + "³" + 1 + "³0³" + 1 });
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(item.Value.User.Id);
                }
                else
                {
                    item.Value.Close();
                }
            }
            return serverMessage;
        }
    }
}
