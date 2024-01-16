using boombang_emulator.src.Controllers;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Handlers.Scenery.Packets.RomanticInteractions;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Interfaces;

namespace boombang_emulator.src.Handlers.Scenery.RomanticInteractions
{
    internal class SendRomanticInteractionHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(137120, new ProcessHandler(SendInteraction));
        }
        private static void SendInteraction(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                Models.Scenery userScenery = client.User!.Scenery!;
                Middlewares.IsRomanticInteractionEnabled(userScenery);

                int interactionId = Convert.ToInt32(clientMessage.Parameters[0, 0]);
                int receiverId = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                if (Enum.IsDefined(typeof(RomanticInteractionsEnum), Convert.ToUInt16(interactionId)) == false)
                {
                    throw new Exception("Interaction not found");
                }
                int userKeyInArea = userScenery.GetClientIdentifier(client.User.Id);

                if (userScenery is PublicPrivateSceneryInterface scenery)
                {
                    RomanticInteraction? romanticInteraction = scenery.GetRomanticInteraction(userKeyInArea, receiverId);
                    if (romanticInteraction == null)
                    {
                        romanticInteraction = new(userKeyInArea, receiverId);
                        scenery.AddRomanticInteraction(romanticInteraction);

                        SendRomanticInteractionPacket.Invoke(client, interactionId, receiverId);
                    }
                }
                else
                {
                    throw new Exception("Scenery is not romantic interaction enabled");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                client.Close();
            }
        }
    }
}
