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
                string jwtToken = clientMessage.Parameters[0, 0];
                client.JwtToken = jwtToken;

                User? user = await UserService.GetUser(client);
                PendingToken pendingToken = SocketWebController.tokensPending[jwtToken];
                if (user == null || pendingToken == null)
                {
                    throw new Exception("User not found");
                }
                SocketWebController.tokensPending.TryRemove(jwtToken, out var removedToken);

                Client? clientFound = SocketGameController.clients[client.Uid];
                clientFound?.Close();

                client.User = user;
                client.WebSocket = pendingToken.WebSocket;

                Thread.Sleep(new TimeSpan(0, 0, 0, 0, 500));
                UserPacket.Invoke(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                client.Close();
            }
        }
    }
}
