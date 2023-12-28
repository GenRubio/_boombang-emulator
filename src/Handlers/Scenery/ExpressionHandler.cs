using boombang_emulator.src.Controllers;
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
                if (client.User == null || client.User.Scenery == null)
                {
                    throw new Exception("-");
                }

                int expressionId = Convert.ToInt32(clientMessage.Parameters[1, 0]);
                if (Middlewares.BlockExpression(client, expressionId))
                {
                    return;
                }

                ExpressionPacket.Invoke(client, expressionId);
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
