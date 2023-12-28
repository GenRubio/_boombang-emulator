using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.FlowerPower.Packets;
using boombang_emulator.src.Handlers.FlowerPower.PacketsWeb;
using boombang_emulator.src.Loaders;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers.FlowerPower
{
    internal class MenuHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(15432, new ProcessHandler(LoadSceneries));
            HandlerController.SetHandler(128125, new ProcessHandler(GoToScenery));
            HandlerController.SetHandler(128121, new ProcessHandler(LoadSceneryObjects));
        }
        private static void LoadSceneries(Client client, ClientMessage clientMessage)
        {
            int typeId = int.Parse(clientMessage.Parameters[0, 0]);
            LoadSceneriesPacket.Invoke(client, typeId);
        }
        private static void GoToScenery(Client client, ClientMessage clientMessage)
        {
            try
            {
                if (client.User == null)
                {
                    throw new Exception("-");
                }

                int accessibilityTypeId = int.Parse(clientMessage.Parameters[0, 0]);
                int scenaryId = int.Parse(clientMessage.Parameters[1, 0]);
                switch(accessibilityTypeId)
                {
                    case 1:
                        PublicScenery publicScenery = PublicSceneryLoader.publicSceneries[scenaryId] ?? throw new Exception("-");
                        client.User.SetScenery(publicScenery);
                        client.User.SetActualPositionInScenery(publicScenery);
                        publicScenery.AddClient(client);

                        LoadUserPacket.Invoke(client, publicScenery);
                        GoToSceneryPacket.Invoke(client, publicScenery);
                        break;
                    case 2:
                        break;
                }
            }
            catch(Exception)
            {
                client.Close();
            }
        }
        private static void LoadSceneryObjects(Client client, ClientMessage clientMessage)
        {
            try
            {
                if (client.User != null && client.User.Scenery != null)
                {
                    switch (client.User.Scenery.TypeId)
                    {
                        case 1:
                            LoadAreaObjectsPacket.Invoke(client);
                            LoadAreaConfigPacket.Invoke(client);
                            break;
                    }
                    client.User.RunPathfinding();
                    UserInSceneryPacketWeb.Invoke(client);
                }
                else
                {
                    throw new Exception("-");
                }
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
