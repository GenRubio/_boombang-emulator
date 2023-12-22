using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boombang_emulator.src.Models
{
    internal class Scenery
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int TypeId { get; set; }
        public int AccessibilityTypeId { get; set; }
        public string Name { get; set; }
        public int UppertPrice { get; set; }
        public int CocoPrice { get; set; }
        public int MaxVisitors { get; set; }
        public string MapArea { get; set; }
        public string RespawnPositions { get; set; }
        public bool Active { get; set; }
        public Scenery(Dictionary<string, object> data)
        {
            this.Id = Convert.ToInt32(data["id"]);
            this.ModelId = Convert.ToInt32(data["model_id"]);
            this.TypeId = Convert.ToInt32(data["type_id"]);
            this.AccessibilityTypeId = Convert.ToInt32(data["accessibility_type_id"]);
            this.Name = (string)data["name"];
            this.UppertPrice = Convert.ToInt32(data["uppert_price"]);
            this.CocoPrice = Convert.ToInt32(data["coco_price"]);
            this.MaxVisitors = Convert.ToInt32(data["max_visitors"]);
            this.MapArea = (string)data["map_area"];
            this.RespawnPositions = (string)data["respawn_positions"];
            this.Active = Convert.ToBoolean(Convert.ToInt32(data["active"]));
        }
        public string ShowData()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
