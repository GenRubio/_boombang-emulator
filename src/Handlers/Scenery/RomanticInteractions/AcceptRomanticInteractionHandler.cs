using boombang_emulator.src.Controllers;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Handlers.Scenery.Packets.RomanticInteractions;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Interfaces;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Handlers.Scenery.RomanticInteractions
{
    internal class AcceptRomanticInteractionHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(137122, new ProcessHandler(AcceptInteraction));
        }
        private static void AcceptInteraction(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                Models.Scenery userScenery = client.User!.Scenery!;
                Middlewares.IsRomanticInteractionEnabled(userScenery);

                int interactionId = Convert.ToInt32(clientMessage.Parameters[0, 0]);
                int receiverId = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                if (Enum.IsDefined(typeof(RomanticInteractionsEnum), interactionId) == false)
                {
                    throw new Exception("Interaction not found");
                }

                Client receiverClient = userScenery.Clients[receiverId] ?? throw new Exception("Receiver not found");

                int userKeyInArea = userScenery.GetClientIdentifier(client.User.Id);
                int receiverKeyInArea = userScenery.GetClientIdentifier(receiverClient.User!.Id);

                if (userScenery is PublicPrivateSceneryInterface scenery)
                {
                    RomanticInteraction? romanticInteraction = scenery.GetRomanticInteraction(userKeyInArea, receiverId);
                    bool isUserNextToReceiver = SceneryUtils.IsUserNextToAnotherUser(client.User, receiverClient.User!);
                    if (romanticInteraction != null
                        && isUserNextToReceiver
                        && IsUserHavePermissionToInteract(interactionId, client.User)
                        && IsUserHavePermissionToInteract(interactionId, receiverClient.User))
                    {
                        scenery.RemoveRomanticInteraction(romanticInteraction);
                        StartInteraction(interactionId, client, receiverClient);
                    }
                }
                else
                {
                    throw new Exception("Scenery is not romantic interaction enabled");
                }
            }
            catch (Exception)
            {
                client.Close();
            }
        }
        private static void StartInteraction(int interactionId, Client client, Client receiverClient)
        {
            client.User!.WalkTrajectory!.Clear();
            receiverClient.User!.WalkTrajectory!.Clear();

            UserActionsEnum.Actions action = UserActionsEnum.Actions.KISS;

            switch (interactionId)
            {
                case (int)RomanticInteractionsEnum.KISS:
                    action = UserActionsEnum.Actions.KISS;
                    break;
                case (int)RomanticInteractionsEnum.DRINK:
                    action = UserActionsEnum.Actions.DRINK;
                    break;
                case (int)RomanticInteractionsEnum.ROSE:
                    action = UserActionsEnum.Actions.ROSE;
                    break;
            }

            client.User!.Actions.SetAction(action);
            receiverClient.User!.Actions.SetAction(action);

            AcceptRomanticInteractionPacket.Invoke(client.User, receiverClient.User, interactionId);
        }
        private static bool IsUserHavePermissionToInteract(int interactionId, User user)
        {
            bool isBlockedAction = false;
            switch (interactionId)
            {
                case (int)RomanticInteractionsEnum.KISS:
                    isBlockedAction = user.Actions.Kiss;
                    break;
                case (int)RomanticInteractionsEnum.DRINK:
                    isBlockedAction = user.Actions.Drink;
                    break;
                case (int)RomanticInteractionsEnum.ROSE:
                    isBlockedAction = user.Actions.Rose;
                    break;
            }
            return !isBlockedAction;
        }
    }
}
