using boombang_emulator.src.Controllers;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Handlers.Scenery.Packets;
using boombang_emulator.src.Models;

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

                int expressionId = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                bool isBlockedAction = false;

                AvatarActionsEnum action;

                switch (expressionId)
                {
                    case (int)ExpressionsEnum.LITTLE_LAUGHTER:
                        isBlockedAction = client.User!.Actions.LittleLaughter;
                        action = AvatarActionsEnum.LITTLE_LAUGHTER;
                        break;
                    case (int)ExpressionsEnum.BIG_LAUGHTER:
                        isBlockedAction = client.User!.Actions.BigLaughter;
                        action = AvatarActionsEnum.BIG_LAUGHTER;
                        break;
                    case (int)ExpressionsEnum.FART:
                        isBlockedAction = client.User!.Actions.Fart;
                        action = AvatarActionsEnum.FART;
                        break;
                    case (int)ExpressionsEnum.SPIT:
                        isBlockedAction = client.User!.Actions.Spit;
                        action = AvatarActionsEnum.SPIT;
                        break;
                    case (int)ExpressionsEnum.IN_LOVE:
                        isBlockedAction = client.User!.Actions.InLove;
                        action = AvatarActionsEnum.IN_LOVE;
                        break;
                    case (int)ExpressionsEnum.SPECIAL:
                        isBlockedAction = client.User!.Actions.Special;
                        action = AvatarActionsEnum.SPECIAL;
                        break;
                    case (int)ExpressionsEnum.CRY:
                        isBlockedAction = client.User!.Actions.Cry;
                        action = AvatarActionsEnum.CRY;
                        break;
                    case (int)ExpressionsEnum.FLY:
                        isBlockedAction = client.User!.Actions.Fly;
                        action = AvatarActionsEnum.FLY;
                        break;
                    default:
                        throw new Exception("Expression not found");
                }
                if (isBlockedAction)
                {
                    return;
                }

                client.User!.StopMoviment();
                client.User!.Actions.SetAction(action, client.User.Avatar.Id);
                ExpressionPacket.Invoke(client, expressionId);
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
