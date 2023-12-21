using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace boombang_emulator.src.Handlers.Auth.Packets
{
    internal class UserPacket
    {
        public static void Invoke(Client client)
        {
            ServerMessage server = new ServerMessage(new byte[] { 120, 121 });
            server.AppendParameter(1);
            server.AppendParameter("God");//Nombre
            server.AppendParameter(2); //Avatar
            server.AppendParameter("64060E000000F6FAFFF6FAFFF6FAFFFFFFFFF6FAFF"); //Colores
            server.AppendParameter("x@gmail.com"); //Email
            server.AppendParameter(20); //Edad
            server.AppendParameter(2);
            server.AppendParameter("BoomBang");
            server.AppendParameter(0);
            server.AppendParameter(1);//Id usuario
            server.AppendParameter(1);//Admin
            server.AppendParameter(1000);//Creditos Oro
            server.AppendParameter(1000);//Creditos Plata
            server.AppendParameter(200);
            server.AppendParameter(5);
            server.AppendParameter(0);
            server.AppendParameter(0);//Regalo peuqeño
            server.AppendParameter(1);//Concurso Actual
            server.AppendParameter(0);//puntos en concurso
            server.AppendParameter(0); //Tutorial islas
            server.AppendParameter("ES");
            server.AppendParameter(0);
            server.AppendParameter(0);
            server.AppendParameter(-1); //Vip
            server.AppendParameter(-1);// Fecha de caducidad VIP
            server.AppendParameter(1);
            server.AppendParameter(0);// Clave de seguridad 0= off 1 = ON
            server.AppendParameter(0);
            server.AppendParameter(0);
            server.AppendParameter(new object[] { 1, 0 });
            server.AppendParameter(0);
            server.AppendParameter(0);
            client.SendData(server);
        }
    }
}
