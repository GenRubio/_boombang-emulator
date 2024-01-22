using boombang_emulator.src.Controllers;
using boombang_emulator.src.Enums;
using boombang_emulator.src.Models;
using boombang_emulator.src.Pathfinding;
using System.Drawing;

namespace boombang_emulator.src.Handlers.Scenery
{
    internal class WalkHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(182, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                bool isBlockedAction = client.User!.Actions.Walk;
                if (isBlockedAction)
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
                client.User!.StopMoviment();
                client.User!.SetWalkTrajectory(endLocation, client);

                client.User!.Actions.SetAction(AvatarActionsEnum.WALK, client.User.Avatar.Id);
            }
            catch (Exception)
            {
                client.Close();
            }
        }
    }
}
