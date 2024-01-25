using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.FlowerPower.Packets
{
    internal class LoadNpcPacket
    {
        public static ServerMessage Invoke(ServerMessage serverMessage)
        {
            serverMessage.AppendParameter(-1);
            return serverMessage;
        }
    }
}
