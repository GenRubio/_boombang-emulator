namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class WatchPacket
    {
        public static void Invoke(Models.Client client, int z)
        {
            if (
                client.User == null
                || client.User.Scenery == null
                || client.User.ActualPositionInScenery == null
               )
            {
                throw new Exception("-");
            }

            int userKeyInArea = client.User.Scenery.GetClientIdentifier(client.User.Id);

            Models.ServerMessage serverMessage = new([135]);
            serverMessage.AppendParameter(userKeyInArea);
            serverMessage.AppendParameter(client.User.ActualPositionInScenery.X);
            serverMessage.AppendParameter(client.User.ActualPositionInScenery.Y);
            serverMessage.AppendParameter(z);
            client.User.Scenery.SendData(serverMessage);
        }
    }
}
