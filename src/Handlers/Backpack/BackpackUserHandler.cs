using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.Backpack.Packets;
using boombang_emulator.src.Handlers.BPad.Packets;
using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boombang_emulator.src.Handlers.Backpack
{
    internal class BackpackUserHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(189180, new ProcessHandler(SetUserObjects));
        }
        private static void SetUserObjects(Client client, ClientMessage clientMessage)
        {
            BackpackUserObjectsPacket.Invoke(client);
        }
    }
}
