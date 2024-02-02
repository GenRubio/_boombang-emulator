using boombang_emulator.src.Models.Interfaces;
using boombang_emulator.src.Models.Messages;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Drawing;

namespace boombang_emulator.src.Models.Scenarios
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
        public bool IsWalkable { get; set; }
        public bool Active { get; set; }
        public ConcurrentDictionary<int, Client> Clients { get; set; }
        public MapArea MapAreaObject { get; set; }
        public Scenery(Dictionary<string, object> data)
        {
            Id = Convert.ToInt32(data["id"]);
            ModelId = Convert.ToInt32(data["model_id"]);
            TypeId = Convert.ToInt32(data["type_id"]);
            AccessibilityTypeId = Convert.ToInt32(data["accessibility_type_id"]);
            Name = (string)data["name"];
            UppertPrice = Convert.ToInt32(data["uppert_price"]);
            CocoPrice = Convert.ToInt32(data["coco_price"]);
            MaxVisitors = Convert.ToInt32(data["max_visitors"]);
            Active = Convert.ToBoolean(Convert.ToInt32(data["active"]));
            IsWalkable = true;
            Clients = [];
            MapAreaObject = new(data);
        }
        public void RemoveUser(User user)
        {
            Client? client = Clients.FirstOrDefault(sceneryClient => sceneryClient.Value.User != null
                           && sceneryClient.Value.User.Id == user.Id).Value;
            if (client != null)
            {
                RemoveClient(client);
            }
        }
        public void RemoveClient(Client client)
        {
            int userKeyInArea = client.User!.Scenery!.GetClientIdentifier(client.User.Id);
            client.User.Scenery.SendData(new([128, 123], [userKeyInArea]));

            client.User!.StopMoviment();

            if (client.User!.Scenery is PublicPrivateSceneryInterface scenery)
            {
                scenery.RemoveAllUserRomanticInteractions(client.User);
            }

            int key = Clients.FirstOrDefault(x => x.Value.User?.Id == client.User.Id).Key;
            Clients.TryRemove(key, out var removedClient);
            client.User.SetScenery(null);
            client.User.Actions.Action.ResetActions();
        }
        public Client? GetClientInPosition(Point position)
        {
            return Clients.FirstOrDefault(sceneryClient => sceneryClient.Value.User != null
            && sceneryClient.Value.User.GetActualPositionInScenery() == position)
                .Value;
        }
        public int GetClientIdentifier(int userId)
        {
            return Clients.FirstOrDefault(sceneryClient => sceneryClient.Value.User != null
               && sceneryClient.Value.User.Id == userId)
                 .Key;
        }
        public void SendData(ServerMessage server, Client? client = null)
        {
            foreach (Client sceneryClient in Clients.Values)
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
