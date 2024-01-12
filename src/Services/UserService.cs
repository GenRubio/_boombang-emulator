using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Services
{
    internal class UserService
    {
        public static async Task<User?> GetUser(Client client, object? requestData = null)
        {
            try
            {
                string url = Config.apiRoute + "/game/user";
                string response = await HttpController.Post(url, client, requestData);
                var data = JsonUtils.Deserialize(response);
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
