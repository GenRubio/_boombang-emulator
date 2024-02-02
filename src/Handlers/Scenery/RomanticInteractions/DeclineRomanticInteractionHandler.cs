using boombang_emulator.src.Controllers;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Exceptions;
using boombang_emulator.src.Handlers.Scenery.Packets.RomanticInteractions;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Interfaces;
using boombang_emulator.src.Models.Messages;

namespace boombang_emulator.src.Handlers.Scenery.RomanticInteractions
{
    internal class DeclineRomanticInteractionHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(137123, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                Models.Scenarios.Scenery userScenery = client.User!.Scenery!;
                Middlewares.IsRomanticInteractionEnabled(userScenery);

                int interactionId = Convert.ToInt32(clientMessage.Parameters[0, 0]);
                int senderId = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                if (Enum.IsDefined(typeof(RomanticInteractionsEnum), Convert.ToUInt16(interactionId)) == false)
                {
                    throw new Exception("Interaction not found");
                }

                Client senderClient = userScenery.Clients[senderId] ?? throw new Exception("Sender not found");

                int userKeyInArea = userScenery.GetClientIdentifier(client.User.Id);
                int senderKeyInArea = userScenery.GetClientIdentifier(senderClient.User!.Id);

                if (userScenery is PublicPrivateSceneryInterface scenery)
                {
                    RomanticInteraction? romanticInteraction = scenery.GetRomanticInteraction(senderId, userKeyInArea) ?? throw new Exception("Interaction not found");

                    scenery.RemoveRomanticInteraction(romanticInteraction);
                    DeclineRomanticInteractionPacket.Invoke(senderClient, senderKeyInArea);
                }
                else
                {
                    throw new Exception("Scenery is not romantic interaction enabled");
                }
            }
            catch (MiddlewareException) { }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
