namespace boombang_emulator.src.Handlers.FlowerPower.Packets
{
    internal class LoadUsersInAreaPacket
    {
        public static Models.ServerMessage Invoke(Models.ServerMessage serverMessage, Models.Scenery scenery)
        {
            foreach (var item in scenery.Clients)
            {
                if (item.Value.User != null)
                {
                    serverMessage.AppendParameter(item.Key); // Id en sala
                    serverMessage.AppendParameter(item.Value.User.Username);
                    serverMessage.AppendParameter(item.Value.User.Avatar.Id);
                    serverMessage.AppendParameter(item.Value.User.Avatar.Color);
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
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        "0³" + 1 + "³0³0³0³" + 1 + "³0³0³" + (1 + 1) + "³" + 1 + "³0³" + 1 + "³" + 1 + "³" + 1 + "³0³" + 1
                    ]);
                    serverMessage.AppendParameter(1);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(0);
                    serverMessage.AppendParameter(1);
                }
                else
                {
                    item.Value.Close();
                }
            }
            return serverMessage;
        }
    }
}
