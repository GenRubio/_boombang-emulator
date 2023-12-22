using boombang_emulator.src.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace boombang_emulator.src.Loaders
{
    internal class SceneryLoader
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static string apiRoute = "http://localhost:8000/api";
        public static Dictionary<int, Scenery> Sceneries = new Dictionary<int, Scenery>();
        public static async Task Invoke()
        {
            try
            {
                string url = apiRoute + "/loaders/sceneries";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var dataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseBody);
                foreach (var data in dataList)
                {
                    Scenery scenery = new Scenery(data);
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
