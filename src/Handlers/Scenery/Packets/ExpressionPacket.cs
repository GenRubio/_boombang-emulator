namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class ExpressionPacket
    {
        public static void Invoke(Models.Client client, int expressionId)
        {
            if (
                client.User == null
                || client.User.Scenery == null
               )
            {
                throw new Exception("-");
            }

            int userKeyInArea = client.User.Scenery.GetClientIdentifier(client.User.Id);

            Models.ServerMessage serverMessage = new([134]);
            serverMessage.AppendParameter(expressionId);
            serverMessage.AppendParameter(userKeyInArea);
            client.User.Scenery.SendData(serverMessage);
        }
    }
}
