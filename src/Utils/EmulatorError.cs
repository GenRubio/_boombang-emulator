﻿using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.FlowerPower.PacketsWeb;

namespace boombang_emulator.src.Utils
{
    internal class EmulatorError
    {
        public static void CloseLauncher()
        {
            foreach (var client in SocketGameController.clients.ToList())
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
