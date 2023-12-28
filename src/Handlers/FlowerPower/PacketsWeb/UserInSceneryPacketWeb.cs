﻿using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;
using Newtonsoft.Json;

namespace boombang_emulator.src.Handlers.FlowerPower.PacketsWeb
{
    internal class UserInSceneryPacketWeb
    {
        public static void Invoke(Client client)
        {
            Dictionary<string, object> data = new()
            {
               {"key", "user-in-scenery"},
               {"test_1", 123},
               {"test_2", true}
            };
            SocketWebController.SendData(client, JsonConvert.SerializeObject(data));
        }
    }
}
