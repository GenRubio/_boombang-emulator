using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class LoadUserPacket
    {
        public static void Invoke(Models.Client client, Models.Scenarios.Scenery scenery)
        {
            if (client.User == null || client.User.ActualPositionInScenery == null)
            {
                throw new Exception("-");
            }

            ServerMessage serverMessage = new([128, 122]);
            serverMessage.AppendParameter(scenery.GetClientIdentifier(client.User.Id));
            serverMessage.AppendParameter(client.User.Username);
            serverMessage.AppendParameter(client.User.Avatar.Id);
            serverMessage.AppendParameter(client.User.Avatar.Color);
            serverMessage.AppendParameter(client.User.ActualPositionInScenery.X);
            serverMessage.AppendParameter(client.User.ActualPositionInScenery.Y);
            serverMessage.AppendParameter(client.User.ActualPositionInScenery.Z);
            serverMessage.AppendParameter("BurBian");
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(Convert.ToString(0) + "³15³16³17");
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(new object[] { 0, 0, 0, 0, 0 });
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(client.User.Avatar.SelectedCoconut);
            serverMessage.AppendParameter(client.User.Avatar.CoconutLevel);
            serverMessage.AppendParameter(new object[] { "Hola", "Hola", "Hola" });
            serverMessage.AppendParameter(new object[] { "Hola", "Hola", "Hola" });
            serverMessage.AppendParameter(new object[] { 50, 50, 50 });
            serverMessage.AppendParameter("Hola");
            serverMessage.AppendParameter(new object[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, "0³" + 1 + "³0³0³0³" + 1 + "³0³0³" + client.User.Avatar.CoconutLevel + "³" + client.User.Avatar.CoconutPoints + "³0³" + client.User.Avatar.CoconutFinishLevelPoints + "³" + 1 + "³" + 1 + "³0³" + 1 });
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(client.User.Id);

            scenery.SendData(serverMessage, client);
        }
    }
}
