using boombang_emulator.src.Controllers;
using Newtonsoft.Json;

namespace boombang_emulator.src.Handlers.FlowerPower.PacketsWeb
{
    internal class RenderAreasCountUserPacketWeb
    {
        public static void Invoke()
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
            SocketWebController.SendDataAll(JsonConvert.SerializeObject(data));
        }
    }
}
