using boombang_emulator.src.Models.Interfaces;
using System.Collections.Concurrent;

namespace boombang_emulator.src.Models.Scenarios
{
    internal class PublicScenery : Scenery, PublicPrivateSceneryInterface
    {
        public int Key { get; set; }
        public int ClientIdentifierAutoIncrement { get; set; }
        public ConcurrentDictionary<string, RomanticInteraction> RomanticInteractions { get; set; }
        public PublicScenery(int key, Dictionary<string, object> data)
            : base(data)
        {
            Key = key;
            ClientIdentifierAutoIncrement = 1;
            RomanticInteractions = [];
        }
        public void AddClient(Client client)
        {
            Clients.TryAdd(ClientIdentifierAutoIncrement++, client);
        }
        public void AddRomanticInteraction(RomanticInteraction romanticInteraction)
        {
            RomanticInteractions.TryAdd(romanticInteraction.Guid, romanticInteraction);
        }
        public void RemoveRomanticInteraction(RomanticInteraction romanticInteraction)
        {
            RomanticInteractions.TryRemove(romanticInteraction.Guid, out var _);
        }
        public void RemoveAllUserRomanticInteractions(User user)
        {
            int userKeyInArea = user!.Scenery!.GetClientIdentifier(user.Id);
            var keysToRemove = RomanticInteractions
             .Where(kvp => kvp.Value.FirstUserKeyInArea == userKeyInArea || kvp.Value.SecondUserKeyInArea == userKeyInArea)
             .Select(kvp => kvp.Key)
             .ToList();
            foreach (var key in keysToRemove)
            {
                RomanticInteractions.TryRemove(key, out _);
            }
        }
        public RomanticInteraction? GetRomanticInteraction(int firstUserKeyInArea, int secondUserKeyInArea)
        {
            return RomanticInteractions
               .FirstOrDefault(kvp => kvp.Value.FirstUserKeyInArea == firstUserKeyInArea && kvp.Value.SecondUserKeyInArea == secondUserKeyInArea)
               .Value;
        }
    }
}
