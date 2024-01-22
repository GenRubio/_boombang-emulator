namespace boombang_emulator.src.Utils
{
    internal class ConsoleUtils
    {
        public static void WriteError(Exception exception)
        {
            if (Config.env == "dev"
                || Config.env == "local"
                || Config.env == "test"
                || Config.env == "testing"
                || Config.env == "development"
                )
            {
                Console.WriteLine("Error: " + exception.Message);
                Console.WriteLine("Stack: " + exception.StackTrace);
            }
        }
    }
}
