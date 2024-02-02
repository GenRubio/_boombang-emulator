using boombang_emulator.src.Exceptions;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Scenarios;

namespace boombang_emulator.src
{
    internal class Middlewares
    {
        public static void IsUserInScenery(Client client)
        {
            if (client.User == null || client.User.Scenery == null || client.User.ActualPositionInScenery == null)
            {
                throw new MiddlewareException("-");
            }
        }
        public static void IsUserUseWalkAutoclick(User user)
        {
            TimeSpan difference = DateTime.Now - user.Avatar.LastClickWalk;
            if (difference.TotalMilliseconds <= 560)
            {
                throw new MiddlewareException("-");
            }
        }
        public static void IsRomanticInteractionEnabled(Scenery scenery)
        {
            if (scenery is not PublicScenery && scenery is not PrivateScenery)
            {
                throw new MiddlewareException("-");
            }
        }
        public static void RingGame(Scenery scenery)
        {
            if (scenery is RingGameScenery)
            {
                throw new MiddlewareException("-");
            }
        }
    }
}
