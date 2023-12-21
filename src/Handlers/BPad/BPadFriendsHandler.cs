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
    internal class BPadFriendsHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(132120, new ProcessHandler(SetFriends));
        }
        private static void SetFriends(Client client, ClientMessage clientMessage)
        {
            BPadFriendsPacket.Invoke(client);
        }
    }
}
