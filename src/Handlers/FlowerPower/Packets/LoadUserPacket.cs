namespace boombang_emulator.src.Handlers.FlowerPower.Packets
{
    internal class LoadUserPacket
    {
        public static void Invoke(Models.Client client, Models.Scenery scenery)
        {
            if (client.User == null)
            {
                throw new Exception("-");
            }

            Models.ServerMessage serverMessage = new([128, 122]);
            serverMessage.AppendParameter(scenery.GetClientIdentifier(client)); // Id en sala
            serverMessage.AppendParameter(client.User.Username);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter("64060E000000F6FAFFF6FAFFF6FAFFFFFFFFF6FAFF");
            serverMessage.AppendParameter(11);
            serverMessage.AppendParameter(11);
            serverMessage.AppendParameter(4);
            serverMessage.AppendParameter("BurBian");
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(12);
            serverMessage.AppendParameter("12³15³16³17");
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter([3, 4, 5, 6, 6]);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(["Hola", "Hola", "Hola"]);
            serverMessage.AppendParameter(["Hola", "Hola", "Hola"]);
            serverMessage.AppendParameter([50, 50, 50]);
            serverMessage.AppendParameter("Hola");
            serverMessage.AppendParameter([ 
                1, 1, 1, 1, 1, 1, 1, 1, 1,1, "0³" + 1 + "³0³0³0³" +1 + "³0³0³" + (1 + 1) + "³" + 1 + "³0³" + 1 + "³" + 1 + "³" + 1 + "³0³" + 1
            ]);
            serverMessage.AppendParameter(1);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(1);

            scenery.SendData(serverMessage, client);
        }
    }
}
