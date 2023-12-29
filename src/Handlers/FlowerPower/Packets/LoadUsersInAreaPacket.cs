namespace boombang_emulator.src.Handlers.FlowerPower.Packets
{
    internal class LoadUsersInAreaPacket
    {
        public static Models.ServerMessage Invoke(Models.ServerMessage serverMessage, Models.Scenery scenery)
        {
            foreach (var item in scenery.Clients)
            {
                if (
                    item.Value.User != null
                    && item.Value.User.Scenery != null
                    && item.Value.User.ActualPositionInScenery != null
                   )
                {
                    serverMessage.AppendParameter(scenery.GetClientIdentifier(item.Value));
                    serverMessage.AppendParameter(item.Value.User.Username);
                    serverMessage.AppendParameter(item.Value.User.Avatar.Id);
                    serverMessage.AppendParameter(item.Value.User.Avatar.Color);
                    serverMessage.AppendParameter(item.Value.User.ActualPositionInScenery.X);
                    serverMessage.AppendParameter(item.Value.User.ActualPositionInScenery.Y);
                    serverMessage.AppendParameter(item.Value.User.ActualPositionInScenery.Z);
                    serverMessage.AppendParameter("BurBian");
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(Convert.ToString(0) + "³15³16³17");
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(new object[] { 0, 0, 0, 0, 0 });
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(new object[] { "Hola", "Hola", "Hola" });
                    serverMessage.AppendParameter(new object[] { "Hola", "Hola", "Hola" });
                    serverMessage.AppendParameter(new object[] { 50, 50, 50 });
                    serverMessage.AppendParameter("Hola");
                    serverMessage.AppendParameter(new object[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, "0³" + 1 + "³0³0³0³" + 1 + "³0³0³" + (1 + 1) + "³" + 1 + "³0³" + 1 + "³" + 1 + "³" + 1 + "³0³" + 1 });
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
