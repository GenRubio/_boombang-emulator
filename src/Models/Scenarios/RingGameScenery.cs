using boombang_emulator.src.Models.Scenarios;

namespace boombang_emulator.src.Models
{
    internal class RingGameScenery : Scenery
    {
        public int Key { get; set; }
        public int ClientIdentifierAutoIncrement { get; set; }
        public RingGameScenery(int key, Dictionary<string, object> data)
            : base(data)
        {
            Key = key;
            ClientIdentifierAutoIncrement = 1;
            IsWalkable = false;
        }
        public void AddClient(Client client)
        {
            Clients.TryAdd(ClientIdentifierAutoIncrement++, client);
        }
    }
}
