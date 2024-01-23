namespace boombang_emulator.src.Utils
{
    internal class ConsoleUtils
    {
        public static void WriteError(Exception exception)
        {
            string[] devEnvironments = ["dev", "local", "test", "testing", "development"];
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logDirectory = Path.Combine(baseDirectory, "Logs");
            string logFileName = $"log_{DateTime.Now:yyyy-MM-dd}.txt";
            string logFilePath = Path.Combine(logDirectory, logFileName);

            if (Array.Exists(devEnvironments, element => element == Config.env)
                || Config.debug
                )
            {
                Console.WriteLine("Error: " + exception.Message);
                Console.WriteLine("Stack: " + exception.StackTrace);
            }

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            using StreamWriter sw = new(logFilePath, true);
            sw.WriteLine("Timestamp: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sw.WriteLine("Error: " + exception.Message);
            sw.WriteLine("Stack: " + exception.StackTrace);
            sw.WriteLine();
        }
    }
}
