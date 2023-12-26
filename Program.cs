using boombang_emulator.src.Controllers;
using boombang_emulator.src.Loaders;

Console.Title = "Boombang Emulator";
Console.WriteLine("Iniciando servidor...");

try
{
    HandlerController.Invoke();
    SocketGameController.Invoke();

    await SceneryLoader.Invoke();
    await PublicSceneryLoader.Invoke();
}
catch (Exception ex)
{
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine("Error: " + ex.Message);
    Console.WriteLine("-----------------------------------------------------------");
    Console.ReadKey(true);
    Console.WriteLine("Saliendo...");
}

Console.WriteLine("-----------------------------------------------------------");
Console.ReadKey(true);
Console.WriteLine("Saliendo...");
