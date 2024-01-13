namespace boombang_emulator.src.Models.SceneryModel
{
    internal class GameScenery : Scenery
    {
        public int Key { get; set; }
        public int ClientIdentifierAutoIncrement { get; set; }
        public GameScenery(int key, Dictionary<string, object> data)
            : base(data)
        {
            Key = key;
            ClientIdentifierAutoIncrement = 1;
        }
        public void AddClient(Client client)
        {
            Clients.TryAdd(ClientIdentifierAutoIncrement++, client);
        }
    }
}
