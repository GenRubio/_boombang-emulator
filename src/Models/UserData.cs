using boombang_emulator.src.Lists;

namespace boombang_emulator.src.Models
{
    internal class UserData
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int CoconutPoints { get; set; }
        public int CoconutFinishLevelPoints { get; set; }
        public int CoconutLevel { get; set; }
        public int SelectedCoconut { get; set; }
        public DateTime LastClickWalk { get; set; }
        public UserData(Dictionary<string, object> data)
        {
            this.Id = Convert.ToInt32(data["avatar_id"]);
            this.Color = (string)data["avatar_color"];
            this.LastClickWalk = DateTime.Now;

            this.CoconutPoints = 200;
            UpdateCoconutLevel();
        }
        public void UpdateLastClickWalk()
        {
            this.LastClickWalk = DateTime.Now;
        }
        public void UpdateCoconutLevel()
        {
            foreach (var (Limit, Level, FinishLevel) in CoconutLevelsList.data)
            {
                if (this.CoconutPoints <= Limit)
                {
                    this.CoconutLevel = Level;
                    this.SelectedCoconut = Level;
                    this.CoconutFinishLevelPoints = FinishLevel;
                    break;
                }
            }
        }
    }
}
