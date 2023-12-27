namespace boombang_emulator
{
    internal class Config
    {
        public static string env = "dev";
        public static string apiRoute = "http://localhost:8000/api";
        public static string webSocketRoute = "http://localhost:3000/";
        public static int port = 2001;
        //Produccion: dotnet publish -r win-x64 --self-contained true -p:PublishSingleFile=true
    }
}
