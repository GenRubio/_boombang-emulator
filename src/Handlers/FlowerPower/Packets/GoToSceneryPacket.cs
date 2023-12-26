namespace boombang_emulator.src.Handlers.FlowerPower.Packets
{
    internal class GoToSceneryPacket
    {
        public static void Invoke(Models.Client client, Models.Scenery scenery)
        {
            Models.ServerMessage serverMessage = new([128, 120]);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(scenery.AccessibilityTypeId);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(scenery.ModelId);
            serverMessage.AppendParameter(scenery.Name);
            serverMessage.AppendParameter(0);
            client.SendData(serverMessage);
        }
    }
}
