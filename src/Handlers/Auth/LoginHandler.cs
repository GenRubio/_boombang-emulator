using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.Auth.Packets;
using boombang_emulator.src.Models;
using boombang_emulator.src.Services;
using System.Net.WebSockets;

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
                PendingToken pendingToken = SocketWebController.tokensPending[client.JwtToken];
                if (user == null || pendingToken == null)
                {
                   throw new Exception("User not found");
                }
                SocketWebController.tokensPending.Remove(client.JwtToken);

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
