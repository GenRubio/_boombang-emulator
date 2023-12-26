using boombang_emulator.src.Models;
using boombang_emulator.src.Services;

namespace boombang_emulator.src.Loaders
{
    internal class PublicSceneryLoader
    {
        private static int autoIncrement = 1;
        public static Dictionary<int, PublicAreaScenery> publicSceneries = [];
        public static async Task Invoke()
        {
            try
            {
                var dataList = await SceneryService.GetAreas();
                foreach (var data in dataList)
                {
                    int key = autoIncrement++;
                    PublicAreaScenery sceneryArea = new(key, data);
                    publicSceneries.Add(key, sceneryArea);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("SceneryLoader: " + ex.Message);
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}
