using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.BPad.Packets;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.BPad
{
    internal class BPadMessagesHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(132121, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            BPadMessagesPacket.Invoke(client);
        }
    }
}
