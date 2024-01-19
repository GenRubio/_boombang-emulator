using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers
{
    internal class PingHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(163, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            client.SendData(new([163], [10]));
        }
    }
}
