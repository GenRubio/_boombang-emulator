using boombang_emulator.src.Enums;
using boombang_emulator.src.Models;

namespace boombang_emulator.src
{
    internal class Middlewares
    {
        public static bool BlockAction(Client client, BlockActionEnum blockActionEnum)
        {
            if (client.User != null && client.User.BlockAction.IsBlocked(blockActionEnum))
            {
                return true;
            }
            return false;
        }
        public static bool BlockExpression(Client client, int expressionId)
        {
            if (client.User != null && client.User.BlockAction.IsBlockedExpression(expressionId))
            {
                return true;
            }
            return false;
        }
        public static void IsUserInScenery(Client client)
        {
            if (client.User == null || client.User.Scenery == null)
            {
                throw new Exception("-");
            }
        }
    }
}
