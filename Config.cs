namespace boombang_emulator
{
    internal class Config
    {
        public static string env;
        public static string apiRoute;
        public static string webSocketRoute;
        public static int port;
        //Produccion: dotnet publish -r win-x64 --self-contained true -p:PublishSingleFile=true
        //dotnet publish -c release -r linux-x64 --self-contained
        public static void Invoke()
        {
            var config = LoadConfiguration(".env");
            env = config.ContainsKey("APP_ENV") ? config["APP_ENV"] : "dev";
            apiRoute = config.ContainsKey("API_ROUTE") ? config["API_ROUTE"] : "http://localhost:8000/api";
            webSocketRoute = config.ContainsKey("WEB_SOCKET_ROUTE") ? config["WEB_SOCKET_ROUTE"] : "http://localhost:3000/";
            port = config.ContainsKey("FLASH_PORT") ? Convert.ToInt32(config["FLASH_PORT"]) : 2000;
        }
        private static Dictionary<string, string> LoadConfiguration(string path)
        {
            var config = new Dictionary<string, string>();
            foreach (var line in File.ReadAllLines(path))
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                {
                    var parts = line.Split('=', 2);
                    if (parts.Length == 2)
                    {
                        config[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
            return config;
        }
    }
}
