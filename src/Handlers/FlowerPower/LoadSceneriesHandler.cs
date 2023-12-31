using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.FlowerPower.PacketsWeb;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers.FlowerPower
{
    internal class LoadSceneriesHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(15432, new ProcessHandler(LoadSceneries));
        }
        private static void LoadSceneries(Client client, ClientMessage clientMessage)
        {
            //int typeId = Convert.ToInt32(clientMessage.Parameters[0, 0]);
            //LoadSceneriesPacket.Invoke(client, typeId);
            if (client.IsInGame == false)
            {
                RenderAreasPacketWeb.Invoke(client);
                LoadingPacketWeb.Invoke(client, false);
                client.IsInGame = true;
            }
        }
    }
}
