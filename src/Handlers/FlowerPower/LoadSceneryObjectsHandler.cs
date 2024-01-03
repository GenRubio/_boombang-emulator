using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.FlowerPower.Packets;
using boombang_emulator.src.HandlersWeb.FlowerPower.Packets;
using boombang_emulator.src.Models;
namespace boombang_emulator.src.Handlers.FlowerPower
{
    internal class LoadSceneryObjectsHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(128121, new ProcessHandler(LoadSceneryObjects));
        }
        private static void LoadSceneryObjects(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                switch (client.User.Scenery.TypeId)
                {
                    case 1:
                        LoadAreaObjectsPacket.Invoke(client);
                        LoadAreaConfigPacket.Invoke(client);
                        break;
                }
                UserInSceneryPacketWeb.Invoke(client);
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
