using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;
using Newtonsoft.Json;

namespace boombang_emulator.src.HandlersWeb.FlowerPower.Packets
{
    internal class RenderAreasCountUserPacketWeb
    {
        public static void Invoke(Client? client)
        {
            List<object> areas = [];
            foreach (var area in Loaders.PublicSceneryLoader.publicSceneries.Values.ToList())
            {
                areas.Add(new
                {
                    area.Id,
                    area.Clients.Count,
                });
            }

            Dictionary<string, object> data = new()
            {
               {"key", "render-areas-count-users"},
               {"areas", areas},
            };
            SocketWebController.SendData(JsonConvert.SerializeObject(data), client);
        }
    }
}
