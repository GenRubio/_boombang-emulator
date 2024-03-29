﻿using boombang_emulator.src.Utils;

namespace boombang_emulator
{
    internal class Config
    {
        public static string env;
        public static bool debug;
        public static bool debugPackets;
        public static string apiRoute;
        public static string webSocketRoute;
        public static int port;
        public static void Invoke()
        {
            var config = LoadConfiguration(".env");
            env = config.ContainsKey("APP_ENV") ? config["APP_ENV"] : "dev";
            debugPackets = config.ContainsKey("DEBUG_PACKETS") ? Convert.ToBoolean(config["DEBUG_PACKETS"]) : false;
            debug = config.ContainsKey("APP_DEBUG") ? Convert.ToBoolean(config["APP_DEBUG"]) : true;
            apiRoute = config.ContainsKey("API_ROUTE") ? config["API_ROUTE"] : "http://localhost:8000/api";
            webSocketRoute = config.ContainsKey("WEB_SOCKET_ROUTE") ? config["WEB_SOCKET_ROUTE"] : "http://localhost:3000/";
            port = config.ContainsKey("FLASH_PORT") ? Convert.ToInt32(config["FLASH_PORT"]) : 2000;
        }
        private static Dictionary<string, string> LoadConfiguration(string path)
        {
            var config = new Dictionary<string, string>();
            try
            {
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
            }
            catch (Exception)
            {
                string errorMessage = "No se pudo cargar el archivo de configuración.";
                ConsoleUtils.WriteError(new Exception(errorMessage));
            }
            return config;
        }
    }
}
