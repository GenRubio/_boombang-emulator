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
                string response = await HttpController.Post("/game/user", client, requestData);
                var data = JsonUtils.Deserialize(response);
                if (data == null)
                {
                    return null;
                }
                return new User(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
