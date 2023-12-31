using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;
using Newtonsoft.Json;

namespace boombang_emulator.src.Handlers.FlowerPower.PacketsWeb
{
    internal class LoadingPacketWeb
    {
        public static void Invoke(Client client, bool loading)
        {

            Dictionary<string, object> data = new()
            {
               {"key", "loading"},
               {"loading", loading},
            };
            SocketWebController.SendData(client, JsonConvert.SerializeObject(data));
        }
    }
}
