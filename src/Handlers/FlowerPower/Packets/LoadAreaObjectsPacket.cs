namespace boombang_emulator.src.Handlers.FlowerPower.Packets
{
    internal class LoadAreaObjectsPacket
    {
        public static void Invoke(Models.Client client)
        {
            Middlewares.IsUserInScenery(client);

            Models.ServerMessage serverMessage = new([128, 121, 120]);
            serverMessage = LoadNpcPacket.Invoke(serverMessage);
            serverMessage = LoadUsersInAreaPacket.Invoke(serverMessage, client.User.Scenery);
            client.SendData(serverMessage);
        }
    }
}
