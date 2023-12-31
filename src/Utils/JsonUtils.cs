using Newtonsoft.Json;

namespace boombang_emulator.src.Utils
{
    internal class JsonUtils
    {
        public static Dictionary<string, object> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(json) ?? [];
        }
        public static List<Dictionary<string, object>> DeserializeList(string json)
        {
            return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json) ?? [];
        }
        public static string Serialize(Dictionary<string, object>? data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            );
        }
    }
}
