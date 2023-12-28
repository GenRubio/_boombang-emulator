using boombang_emulator.src.Enums;
using boombang_emulator.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    }
}
