using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.FlowerPower.Packets;
using boombang_emulator.src.HandlersWeb.FlowerPower.Packets;
using boombang_emulator.src.Loaders;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.SceneryModel;
using System.Net.WebSockets;

namespace boombang_emulator.src.HandlersWeb
{
    internal class GoToAreaHandlerWeb
    {
        public static void Invoke()
        {
            HandlerWebController.SetHandler("go-to-area", new ProcessWebHandler(GoToArea));
        }
        private static void GoToArea(WebSocket webSocket, Client client, Dictionary<string, object> data)
        {
            try
            {
                int scenaryId = Convert.ToInt32(data["scenery_id"]);
                PublicScenery publicScenery = PublicSceneryLoader.publicSceneries[scenaryId] ?? throw new Exception("-");

                if (
                    (client.User.Scenery != null && client.User.Scenery != publicScenery)
                    || client.User.Scenery == null
                    )
                {
                    Utils.SceneryUtils.RemoveUser(client);

                    client.User.SetScenery(publicScenery);
                    client.User.SetActualPositionInScenery(publicScenery);
                    publicScenery.AddClient(client);

                    client.User.RunPathfinding();

                    RenderAreasPacketWeb.Invoke(client);
                    RenderAreasCountUserPacketWeb.Invoke(null);

                    LoadUserPacket.Invoke(client, publicScenery);
                    GoToSceneryPacket.Invoke(client, publicScenery);
                }
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
