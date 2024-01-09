namespace boombang_emulator.src.Models
{
    internal class UserData
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public UserData(Dictionary<string, object> data)
        {
            this.Id = Convert.ToInt32(data["avatar_id"]);
            this.Color = (string)data["avatar_color"];
        }
    }
}
