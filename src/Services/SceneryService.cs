﻿using Newtonsoft.Json;

namespace boombang_emulator.src.Services
{
    internal class SceneryService
    {
        private static readonly HttpClient httpClient = new();
        public static async Task<List<Dictionary<string, object>>> GetAreas()
        {
            try
            {
                string url = Config.apiRoute + "/loaders/areas";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var dataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseBody);
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
                string url = Config.apiRoute + "/loaders/sceneries";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var dataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseBody);
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
