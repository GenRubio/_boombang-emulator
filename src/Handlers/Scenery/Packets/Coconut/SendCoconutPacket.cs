﻿using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.Packets.Coconut
{
    internal class SendCoconutPacket
    {
        public static void Invoke(Models.User user, int coconutId)
        {
            ServerMessage serverMessage = new([184, 120]);
            serverMessage.AppendParameter(user.Id);
            serverMessage.AppendParameter(0);
            serverMessage.AppendParameter(coconutId);
            user.Scenery!.SendData(serverMessage);
        }
    }
}
