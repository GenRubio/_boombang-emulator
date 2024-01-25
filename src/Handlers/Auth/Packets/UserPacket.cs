using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Auth.Packets
{
    internal class UserPacket
    {
        public static void Invoke(Client client)
        {
            if (client.User == null)
            {
                throw new Exception("-");
            }

            ServerMessage serverMessage = new([120, 121]);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(client.User.Username);//Nombre
            serverMessage.AppendParameter(client.User.Avatar.Id); //Avatar
            serverMessage.AppendParameter(client.User.Avatar.Color); //Colores
            serverMessage.AppendParameter("x@gmail.com"); //Email
            serverMessage.AppendParameter(20); //Edad
            serverMessage.AppendParameter(2);
            serverMessage.AppendParameter("BoomBang");
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(client.User.Id);//Id usuario
            serverMessage.AppendParameter(1);//Admin
            serverMessage.AppendParameter(1000);//Creditos Oro
            serverMessage.AppendParameter(1000);//Creditos Plata
            serverMessage.AppendParameter(200);
            serverMessage.AppendParameter(5);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);//Regalo peuqeño
            serverMessage.AppendParameter(1);//Concurso Actual
            serverMessage.AppendParameter(0);//puntos en concurso
            serverMessage.AppendParameter(0); //Tutorial islas
            serverMessage.AppendParameter("ES");
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(-1); //Vip
            serverMessage.AppendParameter(-1);// Fecha de caducidad VIP
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(0);// Clave de seguridad 0= off 1 = ON
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter([1, 0]);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            client.SendData(serverMessage);
        }
    }
}
