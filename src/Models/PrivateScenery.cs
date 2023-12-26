namespace boombang_emulator.src.Models
{
    internal class PrivateScenery : Scenery
    {
        public int Key { get; set; }
        public PrivateScenery(int key, Dictionary<string, object> data)
            : base(data)
        {
            this.Key = key;
        }
    }
}
