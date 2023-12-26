namespace boombang_emulator.src.Models
{
    internal class PublicScenery : Scenery
    {
        public int Key { get; set; }
        public int ClientIdentifierAutoIncrement { get; set; }
        public PublicScenery(int key, Dictionary<string, object> data)
            : base(data)
        {
            this.Key = key;
            this.ClientIdentifierAutoIncrement = 1;
        }
        public void AddClient(Client client)
        {
            Clients.Add(this.ClientIdentifierAutoIncrement++, client);
        }
    }
}
