using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace boombang_emulator.src.Handlers
{
    internal class PingHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(163, new ProcessHandler(Ping));
        }

        private static void Ping(Client client, ClientMessage clientMessage)
        {
            client.SendData(new ServerMessage(new byte[] { 163 }, new object[] { 10 }));
        }
    }
}
