using boombang_emulator.src.Controllers;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Handlers.Scenery.Packets.Uppercut;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Handlers.Scenery.Uppercut
{
    internal class SendUppercutHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(145, new ProcessHandler(Handler));
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

                bool isUserNextToSender = SceneryUtils.IsUserNextToAnotherUser(client.User, receiverClient.User!);

                if (isUserNextToSender
                    && receiverClient.User!.Actions.UppercutActions.IsPermitted()
                    && client.User!.Actions.UppercutActions.IsPermitted())
                {
                    StartInteraction(client, receiverClient);
                }
            }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
            }
        }
        private static void StartInteraction(Client client, Client receiverClient)
        {
            client.User!.StopMoviment();
            receiverClient.User!.StopMoviment();

            AvatarActionsEnum clientAction = AvatarActionsEnum.GIVE_UPPERCUT;
            AvatarActionsEnum receiverAction = AvatarActionsEnum.RECEIVE_UPPERCUT;

            client.User!.Actions.UppercutActions.SetAction(clientAction, client);
            receiverClient.User!.Actions.UppercutActions.SetAction(receiverAction, receiverClient, true);

            SendUppercutPacket.Invoke(client.User, receiverClient.User);
        }
    }
}
