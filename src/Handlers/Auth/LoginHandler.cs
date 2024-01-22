using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.Auth.Packets;
using boombang_emulator.src.Models;
using boombang_emulator.src.Services;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Handlers.Auth
{
    internal class LoginHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(120121, new ProcessHandler(Handler));
        }
        private static async void Handler(Client client, ClientMessage clientMessage)
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
                SocketWebController.tokensPending.TryRemove(jwtToken, out _);

                Client? clientFound = SocketGameController.clients.Values.FirstOrDefault(client => client.User?.Id == user.Id);
                clientFound?.Close();

                client.User = user;
                client.WebSocket = pendingToken.WebSocket;

                Thread.Sleep(new TimeSpan(0, 0, 0, 0, 500));
                UserPacket.Invoke(client);
            }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
                client.Close();
            }
        }
    }
}
