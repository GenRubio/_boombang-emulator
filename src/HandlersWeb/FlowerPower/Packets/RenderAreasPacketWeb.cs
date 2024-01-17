using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;
using Newtonsoft.Json;

namespace boombang_emulator.src.HandlersWeb.FlowerPower.Packets
{
    internal class RenderAreasPacketWeb
    {
        public static void Invoke(Client client)
        {
            List<object> areas = [];
            foreach (var area in Dictionaries.PublicSceneryDictionary.publicSceneries.Values)
            {
                areas.Add(new
                {
                    area.Id,
                    area.Name,
                    UserInArea = area.Clients.Values.Any(value => value.Equals(client)), //UserInArea = area.Clients.ContainsValue(client),
                });
            }

            Dictionary<string, object> data = new()
            {
               {"key", "render-areas"},
               {"areas", areas},
            };
            SocketWebController.SendData(JsonConvert.SerializeObject(data), client);
        }
    }
}
