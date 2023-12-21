using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boombang_emulator.src.Handlers.Catalog.Packets
{
    internal class CatalogPacket
    {
        public static void Invoke(Client client)
        {
            ServerMessage server = new ServerMessage(new byte[] { 189, 133 });
            server.AppendParameter(1);

            server.AppendParameter(2);
            server.AppendParameter("sfsafs");
            //new object[] { 1, -1, 0 }
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter("1");
            server.AppendParameter("1");
            server.AppendParameter("1");
            server.AppendParameter("1");
            server.AppendParameter("1");
            server.AppendParameter("1");
            server.AppendParameter("1");
            server.AppendParameter("1");
            server.AppendParameter("1");
            server.AppendParameter("1");
            server.AppendParameter("1");
            server.AppendParameter("1");
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(1);
            server.AppendParameter(1);
            client.SendData(server);
        }
    }
}
