namespace boombang_emulator.src.Handlers.FlowerPower.Packets
{
    internal class LoadNpcPacket
    {
        public static Models.ServerMessage Invoke(Models.ServerMessage serverMessage)
        {
            serverMessage.AppendParameter(-1);
            return serverMessage;
        }
    }
}
