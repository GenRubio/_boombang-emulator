using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers.Scenery
{
    internal class VotesHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(167, new ProcessHandler(RemainingVotes));
        }
        private static void RemainingVotes(Client client, ClientMessage clientMessage)
        {
            client.SendData(new([167], [1]));
        }
    }
}
