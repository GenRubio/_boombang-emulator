using boombang_emulator.src.Controllers;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Exceptions;
using boombang_emulator.src.Handlers.Scenery.Packets.Coconut;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Handlers.Scenery.Coconut
{
    internal class ChangeCoconutHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(131, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);
                Middlewares.RingGame(client.User!.Scenery!);

                int coconutId = Convert.ToInt32(clientMessage.Parameters[0, 0]);
                if (Enum.IsDefined(typeof(CoconutsEnum), Convert.ToUInt16(coconutId)) == false)
                {
                    throw new Exception("Coconut not found");
                }
                if (coconutId > client.User!.Avatar.CoconutLevel)
                {
                    throw new Exception("Coconut level not reached");
                }
                client.User.Avatar.SelectedCoconut = coconutId;
                ChangeCoconutPacket.Invoke(client.User, coconutId);
            }
            catch (MiddlewareException) { }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
                client.Close();
            }
        }
    }
}
