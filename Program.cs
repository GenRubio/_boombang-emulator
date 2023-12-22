// See https://aka.ms/new-console-template for more information
using boombang_emulator.src.Controllers;
using boombang_emulator.src.Loaders;

Console.Title = "Boombang Emulator";
Console.WriteLine("Iniciando servidor...");

HandlerController.Invoke();
SocketGameController.Invoke();

await SceneryLoader.Invoke();

Console.WriteLine("-----------------------------------------------------------");
Console.ReadKey(true);
Console.WriteLine("Saliendo...");
