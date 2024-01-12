using boombang_emulator.src.Controllers;
using boombang_emulator.src.Models;
using boombang_emulator.src.Pathfinding;
using System.Drawing;

namespace boombang_emulator.src.Handlers.Scenery
{
    internal class WalkHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(182, new ProcessHandler(Walk));
        }
        private static void Walk(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                if (Middlewares.BlockAction(client, Enums.BlockActionEnum.WALK))
                {
                    return;
                }

                string steps = clientMessage.Parameters[1, 0];
                List<Position> listPositions = [];

                for (int i = 0; i < steps.Length; i += 5)
                {
                    if (i + 5 <= steps.Length)
                    {
                        int x = int.Parse(steps.Substring(i, 2));
                        int y = int.Parse(steps.Substring(i + 2, 2));
                        int z = int.Parse(steps.Substring(i + 4, 1));
                        listPositions.Add(new Position(x, y, z));
                    }
                }
                Point endLocation = new(listPositions[^1].X, listPositions[^1].Y);
                client.User!.SetWalkTrajectory(endLocation, client);
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
