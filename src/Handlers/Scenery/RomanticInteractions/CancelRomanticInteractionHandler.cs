using boombang_emulator.src.Controllers;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Handlers.Scenery.Packets.RomanticInteractions;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Interfaces;
using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.RomanticInteractions
{
    internal class CancelRomanticInteractionHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(137124, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                Models.Scenarios.Scenery userScenery = client.User!.Scenery!;
                Middlewares.IsRomanticInteractionEnabled(userScenery);

                int interactionId = Convert.ToInt32(clientMessage.Parameters[0, 0]);
                int receiverId = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                if (Enum.IsDefined(typeof(RomanticInteractionsEnum), Convert.ToUInt16(interactionId)) == false)
                {
                    throw new Exception("Interaction not found");
                }
                Client receiverClient = userScenery.Clients[receiverId] ?? throw new Exception("Receiver not found");

                int userKeyInArea = userScenery.GetClientIdentifier(client.User.Id);
                int receiverKeyInArea = userScenery.GetClientIdentifier(receiverClient.User!.Id);

                if (userScenery is PublicPrivateSceneryInterface scenery)
                {
                    RomanticInteraction? romanticInteraction = scenery.GetRomanticInteraction(userKeyInArea, receiverKeyInArea) ?? throw new Exception("Interaction not found");

                    scenery.RemoveRomanticInteraction(romanticInteraction);
                    CancelRomanticInteractionPacket.Invoke(receiverClient, receiverKeyInArea);
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
    }
}
