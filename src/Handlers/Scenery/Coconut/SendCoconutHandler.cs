using boombang_emulator.src.Controllers;
using boombang_emulator.src.Dictionaries;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Exceptions;
using boombang_emulator.src.Handlers.Scenery.Packets.Coconut;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Handlers.Scenery.Coconut
{
    internal class SendCoconutHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(149, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);
                Middlewares.IsUserUseWalkAutoclick(client.User!);

                Models.Scenarios.Scenery userScenery = client.User!.Scenery!;
                int receiverId = Convert.ToInt32(clientMessage.Parameters[0, 0]);

                if (!userScenery.Clients.TryGetValue(receiverId, out Client? receiverClient) || receiverClient == null)
                {
                    return;
                }

                if (receiverClient.User!.Actions.CoconutAction.IsPermitted())
                {
                    ushort cocoSelected = Convert.ToUInt16(client.User.Avatar.SelectedCoconut);
                    Dictionary<string, object> cocoData = CoconutsDictionary.data[cocoSelected];
                    AvatarActionsEnum action = (AvatarActionsEnum)cocoData["receiver_action"];
                    int cocoId = Convert.ToInt32(cocoData["coconut_id"]);

                    receiverClient.User!.StopMoviment();
                    receiverClient.User!.Actions.CoconutAction.SetAction(action, cocoId);

                    SendCoconutPacket.Invoke(receiverClient.User, cocoId);
                }
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
