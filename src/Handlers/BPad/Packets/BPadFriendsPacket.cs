using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boombang_emulator.src.Handlers.BPad.Packets
{
    internal class BPadFriendsPacket
    {
        public static void Invoke(Client client)
        {
            ServerMessage server = new ServerMessage(new byte[] { 132, 120 });
            server.AppendParameter(0);
            client.SendData(server);
        }
    }
}
