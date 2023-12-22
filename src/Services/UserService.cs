using boombang_emulator.src.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace boombang_emulator.src.Services
{
    internal class UserService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public static async Task<User?> GetUser(Client client, object? requestData = null)
        {
            try
            {
                string url = client.apiRoute +  "/game/user";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", client.jwtToken);
                var jsonContent = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(responseBody);
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
