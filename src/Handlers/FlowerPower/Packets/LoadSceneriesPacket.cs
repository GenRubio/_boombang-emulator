using boombang_emulator.src.Loaders;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Handlers.FlowerPower.Packets
{
    internal class LoadSceneriesPacket
    {
        public static void Invoke(Client client, int typeId)
        {

            ServerMessage serverMessage = new([154, 32]);
            serverMessage.AppendParameter(typeId);
            switch (typeId)
            {
                case 1:
                    foreach (PublicAreaScenery sceneryArea in PublicSceneryLoader.publicSceneries.Values.ToList())
                    {
                        serverMessage.AppendParameter([
                            sceneryArea.TypeId,
                            sceneryArea.TypeId,
                            sceneryArea.Key,
                            sceneryArea.Name,
                            sceneryArea.Clients.Count,
                            0,
                            0,
                            0,
                            -1,
                            0
                        ]);
                    }
                    break;
            }
            client.SendData(serverMessage);
        }
    }
}
