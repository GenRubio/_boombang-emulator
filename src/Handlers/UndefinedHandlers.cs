using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers
{
    internal class UndefinedHandlers
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(120149, new ProcessHandler(Undefined));
            HandlerController.SetHandler(120141, new ProcessHandler(Undefined));
            HandlerController.SetHandler(143, new ProcessHandler(Undefined));
            HandlerController.SetHandler(142, new ProcessHandler(Undefined));
            HandlerController.SetHandler(120134, new ProcessHandler(Undefined_120_134));
        }

        private static void Undefined(Client client, ClientMessage clientMessage)
        {
           
        }

        private static void Undefined_120_134(Client client, ClientMessage clientMessage)
        {
            client.SendData(new([120, 134], [1]));
        }
    }
}
