using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace boombang_emulator.src.Handlers.Scenery.Packets
{
    internal class LoadUserPacket
    {
        public static void Invoke(Client client)
        {
            ServerMessage server = new ServerMessage(new byte[] { 128, 122 });
            server.AppendParameter(1); // Id en sala
            server.AppendParameter("God");
            server.AppendParameter(1);
            server.AppendParameter("64060E000000F6FAFFF6FAFFF6FAFFFFFFFFF6FAFF");
            server.AppendParameter(11);
            server.AppendParameter(11);
            server.AppendParameter(4);
            server.AppendParameter("BurBian");
            server.AppendParameter(1);
            server.AppendParameter(12);
            server.AppendParameter(Convert.ToString(1 >= 1 ? 12 : 0) + "³15³16³17");
            server.AppendParameter(0);
            server.AppendParameter(new object[] { 3, 4, 5, 6, 6 });
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(new object[] { "Hola", "Hola", "Hola" });
            server.AppendParameter(new object[] { "Hola", "Hola", "Hola" });
            server.AppendParameter(new object[] { 50, 50, 50 });
            server.AppendParameter("Hola");
            server.AppendParameter(new object[] { 
                1, 1, 1, 1, 1, 1, 1, 1, 1,1, "0³" + 1 + "³0³0³0³" +1 + "³0³0³" + (1 + 1) + "³" + 1 + "³0³" + 1 + "³" + 1 + "³" + 1 + "³0³" + 1
            });
            server.AppendParameter(1);
            server.AppendParameter(0);
            server.AppendParameter(0);
            server.AppendParameter(0);
            server.AppendParameter(1);
        }
    }
}
