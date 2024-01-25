using boombang_emulator.src.Controllers;
using boombang_emulator.src.Dictionaries;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Handlers.Scenery.Packets;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Handlers.Scenery
{
    internal class ExpressionHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(134, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                if (client.User!.Actions.ExpressionAction.IsPermitted())
                {
                    int expressionId = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                    AvatarActionsEnum action = ExpressionsDictionary.data[Convert.ToUInt16(expressionId)];

                    client.User!.StopMoviment();
                    client.User!.Actions.ExpressionAction.SetAction(action);
                    ExpressionPacket.Invoke(client.User, expressionId);
                }
            }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
                client.Close();
            }
        }
    }
}
