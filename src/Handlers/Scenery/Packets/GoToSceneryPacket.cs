using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class GoToSceneryPacket
    {
        public static void Invoke(Client client)
        {
            ServerMessage server = new ServerMessage(new byte[] { 128, 120 });
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(0);
            server.AppendParameter(0);
            server.AppendParameter(0);
            server.AppendParameter(0);
            server.AppendParameter(1);
            server.AppendParameter("Test");
            server.AppendParameter(0);
            client.SendData(server);
        }
    }
}
