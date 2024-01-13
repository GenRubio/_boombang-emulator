using boombang_emulator.src.Models.SceneryModel;
using boombang_emulator.src.Services;

namespace boombang_emulator.src.Loaders
{
    internal class PublicSceneryLoader
    {
        private static int autoIncrement = 1;
        public static Dictionary<int, PublicScenery> publicSceneries = [];
        public static async Task Invoke()
        {
            try
            {
                var dataList = await PublicSceneryService.GetAll();
                foreach (var data in dataList)
                {
                    int key = autoIncrement++;
                    publicSceneries.Add(key, new PublicScenery(key, data));
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
