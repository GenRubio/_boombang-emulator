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
            HandlerController.SetHandler(134, new ProcessHandler(Expression));
        }
        private static void Expression(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                int expressionId = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                bool isBlockedAction = false;
                UserActionsEnum.Actions action = UserActionsEnum.Actions.LITTLE_LAUGHTER;

                switch (expressionId)
                {
                    case (int)ExpressionsEnum.LITTLE_LAUGHTER:
                        isBlockedAction = client.User!.Actions.LittleLaughter;
                        action = UserActionsEnum.Actions.LITTLE_LAUGHTER;
                        break;
                    case (int)ExpressionsEnum.BIG_LAUGHTER:
                        isBlockedAction = client.User!.Actions.BigLaughter;
                        action = UserActionsEnum.Actions.BIG_LAUGHTER;
                        break;
                    case (int)ExpressionsEnum.FART:
                        isBlockedAction = client.User!.Actions.Fart;
                        action = UserActionsEnum.Actions.FART;
                        break;
                    case (int)ExpressionsEnum.SPIT:
                        isBlockedAction = client.User!.Actions.Spit;
                        action = UserActionsEnum.Actions.SPIT;
                        break;
                    case (int)ExpressionsEnum.IN_LOVE:
                        isBlockedAction = client.User!.Actions.InLove;
                        action = UserActionsEnum.Actions.IN_LOVE;
                        break;
                    case (int)ExpressionsEnum.SPECIAL:
                        isBlockedAction = client.User!.Actions.Special;
                        action = UserActionsEnum.Actions.SPECIAL;
                        break;
                    case (int)ExpressionsEnum.CRY:
                        isBlockedAction = client.User!.Actions.Cry;
                        action = UserActionsEnum.Actions.CRY;
                        break;
                    case (int)ExpressionsEnum.FLY:
                        isBlockedAction = client.User!.Actions.Fly;
                        action = UserActionsEnum.Actions.FLY;
                        break;
                }
                if (isBlockedAction)
                {
                    return;
                }
                client.User!.Actions.SetAction(action);
                ExpressionPacket.Invoke(client, expressionId);
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
