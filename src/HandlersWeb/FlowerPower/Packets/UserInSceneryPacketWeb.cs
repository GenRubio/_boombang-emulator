using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;
using Newtonsoft.Json;

namespace boombang_emulator.src.HandlersWeb.FlowerPower.Packets
{
    internal class UserInSceneryPacketWeb
    {
        public static void Invoke(Client client)
        {
            Dictionary<string, object> data = new()
            {
               {"key", "user-in-scenery"},
               {"test_1", client.User.Username},
               {"test_2", true}
            };
            SocketWebController.SendData(JsonConvert.SerializeObject(data), client);
        }
    }
}
