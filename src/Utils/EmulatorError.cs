using boombang_emulator.src.Controllers;
using boombang_emulator.src.HandlersWeb.FlowerPower.Packets;

namespace boombang_emulator.src.Utils
{
    internal class EmulatorError
    {
        public static void CloseLauncher()
        {
            foreach (var client in SocketGameController.clients.Values)
            {
                try
                {
                    LoadingPacketWeb.Invoke(client, false);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
