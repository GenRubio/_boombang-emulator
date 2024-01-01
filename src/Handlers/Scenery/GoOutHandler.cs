using boombang_emulator.src.Controllers;
using boombang_emulator.src.HandlersWeb.FlowerPower.Packets;
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
                if (client.User == null || client.User.Scenery == null)
                {
                    throw new Exception("-");
                }

                int userKeyInArea = client.User.Scenery.GetClientIdentifier(client.User.Id);
                client.User.Scenery.SendData(new([128, 123], [userKeyInArea]));
                client.User.Scenery.RemoveClient(client);
                client.SendData(new([128, 124]));

                RenderAreasPacketWeb.Invoke(client);
                RenderAreasCountUserPacketWeb.Invoke(null);
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
