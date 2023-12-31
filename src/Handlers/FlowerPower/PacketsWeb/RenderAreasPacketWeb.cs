using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;
using Newtonsoft.Json;

namespace boombang_emulator.src.Handlers.FlowerPower.PacketsWeb
{
    internal class RenderAreasPacketWeb
    {
        public static void Invoke(Client client)
        {
            List<object> areas = [];
            foreach (var area in Loaders.PublicSceneryLoader.publicSceneries.Values)
            {
                areas.Add(new
                {
                    Id = area.Id,
                    Name = area.Name,
                    UserInArea = area.Clients.ContainsValue(client),
                });
            }

            Dictionary<string, object> data = new()
            {
               {"key", "render-areas"},
               {"areas", areas},
            };
            SocketWebController.SendData(client, JsonConvert.SerializeObject(data));
        }
    }
}
