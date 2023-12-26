﻿using boombang_emulator.src.Models;
using boombang_emulator.src.Services;

namespace boombang_emulator.src.Loaders
{
    internal class SceneryLoader
    {
        public static Dictionary<int, Scenery> Sceneries = [];
        public static async Task Invoke()
        {
            try
            {
                var dataList = await SceneryService.GetSceneries();
                foreach (var data in dataList)
                {
                    Scenery scenery = new(data);
                    Sceneries.Add(scenery.Id, scenery);
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
