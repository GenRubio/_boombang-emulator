using boombang_emulator.src.Controllers;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Services
{
    internal class SceneryService
    {
        public static async Task<List<Dictionary<string, object>>> GetAreas()
        {
            try
            {
                string url = Config.apiRoute + "/game/loaders/areas";
                string response = await HttpController.Get(url);
                var dataList = JsonUtils.DeserializeList(response);
                if (dataList == null)
                {
                    return [];
                }
                return dataList;
            }
            catch (Exception)
            {
                return [];
            }
        }
        public static async Task<List<Dictionary<string, object>>> GetSceneries()
        {
            try
            {
                string url = Config.apiRoute + "/game/loaders/sceneries";
                string response = await HttpController.Get(url);
                var dataList = JsonUtils.DeserializeList(response);
                if (dataList == null)
                {
                    return [];
                }
                return dataList;
            }
            catch (Exception)
            {
                return [];
            }
        }
    }
}
