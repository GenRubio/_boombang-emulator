using boombang_emulator.src.Models;

namespace boombang_emulator.src
{
    internal class Middlewares
    {
        public static void IsUserInScenery(Client client)
        {
            if (client.User == null || client.User.Scenery == null || client.User.ActualPositionInScenery == null)
            {
                throw new Exception("-");
            }
        }
        public static void IsRomanticInteractionEnabled(Scenery scenery)
        {
            if (scenery is not PublicScenery && scenery is not PrivateScenery)
            {
                throw new Exception("-");
            }
        }
    }
}
