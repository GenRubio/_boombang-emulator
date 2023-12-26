using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.Auth.Packets;
using boombang_emulator.src.Models;
using boombang_emulator.src.Services;

namespace boombang_emulator.src.Handlers.Auth
{
    internal class LoginHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(120121, new ProcessHandler(Login));
        }
        private static async void Login(Client client, ClientMessage clientMessage)
        {
            try
            {
                client.JwtToken = clientMessage.Parameters[0, 0];
                client.WebsocketToken = clientMessage.Parameters[1, 0];

                User? user = await UserService.GetUser(client);
                if (user != null)
                {
                    client.User = user;
                    Thread.Sleep(new TimeSpan(0, 0, 0, 0, 500));
                    UserPacket.Invoke(client);
                }
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
