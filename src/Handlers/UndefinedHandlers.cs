using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers
{
    internal class UndefinedHandlers
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(120149, new ProcessHandler(Handler));
            HandlerController.SetHandler(120141, new ProcessHandler(Handler));
            HandlerController.SetHandler(143, new ProcessHandler(Handler));
            HandlerController.SetHandler(142, new ProcessHandler(Handler));
            HandlerController.SetHandler(120134, new ProcessHandler(Handler_120_134));
        }

        private static void Handler(Client client, ClientMessage clientMessage)
        {

        }

        private static void Handler_120_134(Client client, ClientMessage clientMessage)
        {
            client.SendData(new([120, 134], [1]));
        }
    }
}
