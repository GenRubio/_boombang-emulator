using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Services
{
    internal class SceneryService
    {
        private static readonly HttpClient httpClient = new();
        public static async Task<List<Dictionary<string, object>>> GetAreas()
        {
            try
            {
                string url = Config.apiRoute + "/game/loaders/areas";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var dataList = JsonUtils.DeserializeList(responseBody);
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
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var dataList = JsonUtils.DeserializeList(responseBody);
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
