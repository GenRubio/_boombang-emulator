using boombang_emulator.src.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace boombang_emulator.src.Controllers
{
    internal class HttpController
    {
        private static readonly HttpClient httpClient = new();
        public static async Task<string> Get(string url)
        {
            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static async Task<string> Post(string url, Client? client = null, object? data = null)
        {
            try
            {
                if (client != null)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", client.JwtToken);
                }
                var jsonContent = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
