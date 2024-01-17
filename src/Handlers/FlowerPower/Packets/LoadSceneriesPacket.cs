using boombang_emulator.src.Dictionaries;
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
                    foreach (PublicScenery scenery in PublicSceneryDictionary.publicSceneries.Values)
                    {
                        serverMessage.AppendParameter([
                            scenery.TypeId,
                            scenery.TypeId,
                            scenery.Key,
                            scenery.Name,
                            scenery.Clients.Count,
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
