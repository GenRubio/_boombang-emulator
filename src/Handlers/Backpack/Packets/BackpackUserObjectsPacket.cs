using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace boombang_emulator.src.Handlers.Backpack.Packets
{
    internal class BackpackUserObjectsPacket
    {
        public static void Invoke(Client client)
        {
            ServerMessage server = new ServerMessage(new byte[] { 189, 180 });
            client.SendData(server);
        }
    }
}
