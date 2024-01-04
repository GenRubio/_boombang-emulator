using boombang_emulator.src.Models;

namespace boombang_emulator.src.Utils
{
    internal class SceneryUtils
    {
        public static void RemoveUser(Client client)
        {
            if (client.User != null && client.User.Scenery != null)
            {
                int userKeyInArea = client.User.Scenery.GetClientIdentifier(client.User.Id);
                client.User.Scenery.SendData(new([128, 123], [userKeyInArea]));
                client.User.Scenery.RemoveClient(client);
                client.SendData(new([128, 124]));
            }
        }
    }
}
