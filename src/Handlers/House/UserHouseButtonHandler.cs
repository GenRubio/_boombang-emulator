using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers.House
{
    internal class UserHouseButtonHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(120143, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            client.SendData(new([120, 143], [0, -1, 1, 25]));
        }
    }
}
