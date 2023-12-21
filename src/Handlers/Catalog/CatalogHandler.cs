﻿using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.BPad.Packets;
using boombang_emulator.src.Handlers.Catalog.Packets;
using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boombang_emulator.src.Handlers.Catalog
{
    internal class CatalogHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(189133, new ProcessHandler(SetCatalog));
        }
        private static void SetCatalog(Client client, ClientMessage clientMessage)
        {
            CatalogPacket.Invoke(client);
        }
    }
}
