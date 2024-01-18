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
                int senderId = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                if (Enum.IsDefined(typeof(RomanticInteractionsEnum), Convert.ToUInt16(interactionId)) == false)
                {
                    throw new Exception("Interaction not found");
                }

                Client senderClient = userScenery.Clients[senderId] ?? throw new Exception("Receiver not found");

                int userKeyInArea = userScenery.GetClientIdentifier(client.User.Id);
                int senderKeyInArea = userScenery.GetClientIdentifier(senderClient.User!.Id);

                if (userScenery is PublicPrivateSceneryInterface scenery)
                {
                    RomanticInteraction? romanticInteraction = scenery.GetRomanticInteraction(senderId, userKeyInArea);
                    bool isUserNextToSender = SceneryUtils.IsUserNextToAnotherUser(client.User, senderClient.User!);
                    if (romanticInteraction != null
                        && isUserNextToSender
                        && IsUserHavePermissionToInteract(interactionId, client.User)
                        && IsUserHavePermissionToInteract(interactionId, senderClient.User))
                    {
                        scenery.RemoveRomanticInteraction(romanticInteraction);
                        StartInteraction(interactionId, client, senderClient);
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
        private static void StartInteraction(int interactionId, Client client, Client senderClient)
        {
            client.User!.StopMoviment();
            senderClient.User!.StopMoviment();

            AvatarActionsEnum senderAction;
            AvatarActionsEnum clientAction;

            switch (interactionId)
            {
                case (int)RomanticInteractionsEnum.KISS:
                    senderAction = AvatarActionsEnum.GIVE_KISS;
                    clientAction = AvatarActionsEnum.RECEIVE_KISS;
                    break;
                case (int)RomanticInteractionsEnum.DRINK:
                    senderAction = AvatarActionsEnum.GIVE_DRINK;
                    clientAction = AvatarActionsEnum.RECEIVE_DRINK;
                    break;
                case (int)RomanticInteractionsEnum.ROSE:
                    senderAction = AvatarActionsEnum.GIVE_ROSE;
                    clientAction = AvatarActionsEnum.RECEIVE_ROSE;
                    break;
                default:
                    throw new Exception("Interaction not found");
            }

            client.User!.Actions.SetAction(clientAction, client.User.Avatar.Id);
            senderClient.User!.Actions.SetAction(senderAction, senderClient.User.Avatar.Id);

            AcceptRomanticInteractionPacket.Invoke(client.User, senderClient.User, interactionId);
        }
        private static bool IsUserHavePermissionToInteract(int interactionId, User user)
        {
            bool isBlockedAction = false;
            switch (interactionId)
            {
                case (int)RomanticInteractionsEnum.KISS:
                    isBlockedAction = user.Actions.GiveKiss || user.Actions.ReceiveKiss;
                    break;
                case (int)RomanticInteractionsEnum.DRINK:
                    isBlockedAction = user.Actions.GiveDrink || user.Actions.ReceiveDrink;
                    break;
                case (int)RomanticInteractionsEnum.ROSE:
                    isBlockedAction = user.Actions.GiveRose || user.Actions.ReceiveRose;
                    break;
            }
            return !isBlockedAction;
        }
    }
}
