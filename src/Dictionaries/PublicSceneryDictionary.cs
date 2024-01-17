using boombang_emulator.src.Models;
using boombang_emulator.src.Services;
using System.Collections.Concurrent;

namespace boombang_emulator.src.Dictionaries
{
    internal class PublicSceneryDictionary
    {
        private static int autoIncrement = 1;
        public static ConcurrentDictionary<int, PublicScenery> publicSceneries = [];
        public static async Task Invoke()
        {
            try
            {
                var dataList = await PublicSceneryService.GetAll();
                foreach (var data in dataList)
                {
                    int key = autoIncrement++;
                    publicSceneries.TryAdd(key, new PublicScenery(key, data));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
