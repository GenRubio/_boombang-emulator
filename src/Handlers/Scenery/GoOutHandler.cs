using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers.Scenery
{
    internal class GoOutHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(128124, new ProcessHandler(GoOut));
        }
        private static void GoOut(Client client, ClientMessage clientMessage)
        {
            try
            {
                if (client.User.Scenery == null)
                {
                    throw new Exception("-");
                }
                client.User.Scenery.RemoveClient(client);
                client.SendData(new ServerMessage([128, 124]));
            }
            catch(Exception)
            {
                client.Close();
            }
        }
    }
}
