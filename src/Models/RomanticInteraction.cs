namespace boombang_emulator.src.Models
{
    internal class RomanticInteraction
    {
        public string Guid { get; set; }
        public int FirstUserKeyInArea { get; set; }
        public int SecondUserKeyInArea { get; set; }
        public RomanticInteraction(int firstUserKeyInArea, int secondUserKeyInArea)
        {
            this.Guid = System.Guid.NewGuid().ToString();
            this.FirstUserKeyInArea = firstUserKeyInArea;
            this.SecondUserKeyInArea = secondUserKeyInArea;
        }
    }
}
