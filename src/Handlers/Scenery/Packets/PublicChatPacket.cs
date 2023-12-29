namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class PublicChatPacket
    {
        public static void Invoke(Models.Client client, string message)
        {
            if (
                client.User == null
                || client.User.Scenery == null
               )
            {
                throw new Exception("-");
            }

            int userKeyInArea = client.User.Scenery.GetClientIdentifier(client.User.Id);

            Models.ServerMessage serverMessage = new([186]);
            serverMessage.AppendParameter(userKeyInArea);
            serverMessage.AppendParameter(message);
            serverMessage.AppendParameter((int)Enums.ColorChatsEnum.Normal);
            client.User.Scenery.SendData(serverMessage);
        }
    }
}
