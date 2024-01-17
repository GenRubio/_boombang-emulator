using boombang_emulator;
using boombang_emulator.src.Controllers;
using boombang_emulator.src.Dictionaries;
using boombang_emulator.src.Utils;

Console.Title = "Boombang Emulator";
Console.WriteLine("Iniciando servidor...");

try
{
    AppDomain.CurrentDomain.AssemblyResolve += Embedding.CurrentDomain_AssemblyResolve;
    Config.Invoke();

    HandlerController.Invoke();
    HandlerWebController.Invoke();
    SocketGameController.Invoke();
    SocketWebController.Invoke();

    await PublicSceneryDictionary.Invoke();
}
catch (Exception ex)
{
    EmulatorError.CloseLauncher();
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine("Error: " + ex.Message);
    Console.WriteLine("-----------------------------------------------------------");
    Console.ReadKey(true);
    Console.WriteLine("Saliendo...");
}

Console.WriteLine("-----------------------------------------------------------");
Console.ReadKey(true);
Console.WriteLine("Saliendo...");
