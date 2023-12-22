using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.Auth.Packets;
using boombang_emulator.src.Models;
using boombang_emulator.src.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

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
            client.jwtToken = clientMessage.parameters[0, 0];
            client.websocketToken = clientMessage.parameters[1, 0];

            //User? user = await UserService.GetUser(client);
            //if (user != null)
            //{
            //    Console.WriteLine("User: " + user.Username);
            //    client.user = user;
            //    Thread.Sleep(new TimeSpan(0, 0, 0, 0, 500));
            //    UserPacket.Invoke(client);
            //}
            Thread.Sleep(new TimeSpan(0, 0, 0, 0, 500));
            UserPacket.Invoke(client);
        }
    }
}
