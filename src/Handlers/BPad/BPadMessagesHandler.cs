using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.BPad.Packets;
using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boombang_emulator.src.Handlers.BPad
{
    internal class BPadMessagesHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(132121, new ProcessHandler(SetMessages));
        }
        private static void SetMessages(Client client, ClientMessage clientMessage)
        {
            BPadMessagesPacket.Invoke(client);
        }
    }
}
