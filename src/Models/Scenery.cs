using Newtonsoft.Json;
using System.Drawing;

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
        public bool Active { get; set; }
        public Dictionary<int, Client> Clients { get; set; }
        public MapArea MapAreaObject { get; set; }
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
            this.Active = Convert.ToBoolean(Convert.ToInt32(data["active"]));
            this.Clients = [];
            this.MapAreaObject = new(data);
        }
        public void RemoveClient(Client client)
        {
            if (client.User == null)
            {
                return;
            }
            Clients.Remove(Clients.FirstOrDefault(x => x.Value.User?.Id == client.User.Id).Key);
            client.User.SetScenery(null);
        }
        public Client? GetClientInPosition(Point position)
        {
            foreach (KeyValuePair<int, Client> sceneryClient in this.Clients)
            {
                if (sceneryClient.Value.User != null && sceneryClient.Value.User.GetActualPositionInScenery() == position)
                {
                    return sceneryClient.Value;
                }
            }
            return null;
        }
        public int GetClientIdentifier(Client client)
        {
            foreach (KeyValuePair<int, Client> sceneryClient in this.Clients)
            {
                if (sceneryClient.Value == client)
                {
                    return sceneryClient.Key;
                }
            }
            client.Close();
            return 0;
        }
        public int GetClientIdentifier(int userId)
        {
            foreach (KeyValuePair<int, Client> sceneryClient in this.Clients)
            {
                if (sceneryClient.Value.User != null && sceneryClient.Value.User.Id == userId)
                {
                    return sceneryClient.Key;
                }
            }
            return 0;
        }
        public void SendData(ServerMessage server, Client? client = null)
        {
            foreach (Client sceneryClient in this.Clients.Values)
            {
                if (sceneryClient == client)
                {
                    continue;
                }
                sceneryClient.SendData(server);
            }
        }
        public string ShowData()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
