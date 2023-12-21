using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.Catalog.Packets;
using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace boombang_emulator.src.Handlers.House
{
    internal class UserHouseButtonHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(120143, new ProcessHandler(SetHouse));
        }
        private static void SetHouse(Client client, ClientMessage clientMessage)
        {
            client.SendData(new ServerMessage(new byte[] { 120, 143 }, new object[] { 0, -1, 1, 25 }));
        }
    }
}
