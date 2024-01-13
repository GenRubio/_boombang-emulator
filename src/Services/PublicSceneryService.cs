using boombang_emulator.src.Controllers;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Services
{
    internal class PublicSceneryService
    {
        public static async Task<List<Dictionary<string, object>>> GetAll()
        {
            try
            {
                string response = await HttpController.Get("/game/loaders/areas");
                return JsonUtils.DeserializeList(response) ?? ([]);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
