using boombang_emulator.src.Controllers;
using boombang_emulator.src.Exceptions;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Handlers.Scenery
{
    internal class VotesHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(167, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                client.SendData(new([167], [1]));
            }
            catch (MiddlewareException) { }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
                client.Close();
            }
        }
    }
}
