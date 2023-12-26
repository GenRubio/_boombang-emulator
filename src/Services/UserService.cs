using boombang_emulator.src.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace boombang_emulator.src.Services
{
    internal class UserService
    {
        private static readonly HttpClient httpClient = new();
        public static async Task<User?> GetUser(Client client, object? requestData = null)
        {
            try
            {
                string url = Config.apiRoute +  "/game/user";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", client.JwtToken);
                var jsonContent = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);
                if (data == null)
                {
                    return null;
                }
                return new User(data);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                client.Close();
                return null;
            }
        }
    }
}
