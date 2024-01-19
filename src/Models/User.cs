using boombang_emulator.src.Handlers.Scenery.Packets;
using boombang_emulator.src.Pathfinding;
using boombang_emulator.src.Utils;
using System.Drawing;

namespace boombang_emulator.src.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Scenery? Scenery { get; set; }
        public WalkTrajectory? WalkTrajectory { get; set; }
        public Position? ActualPositionInScenery { get; set; }
        public UserData Avatar { get; set; }
        public ActionsEngine Actions { get; set; }
        public CancellationTokenSource? ResetPathfindingSource { get; set; }
        public User(Dictionary<string, object> data)
        {
            this.Id = Convert.ToInt32(data["id"]);
            this.Username = (string)data["username"];
            this.Email = (string)data["email"];
            this.Actions = new();
            this.Avatar = new(JsonUtils.Deserialize((string)data["content"]));
        }
        public void SetWalkTrajectory(Point endLocation, Client client)
        {
            this.WalkTrajectory = new(endLocation, client);
        }
        public void SetScenery(Scenery? scenery)
        {
            this.Scenery = scenery;
        }
        public Point GetActualPositionInScenery()
        {
            if (this.ActualPositionInScenery == null)
            {
                throw new Exception("-");
            }
            int x = this.ActualPositionInScenery.X;
            int y = this.ActualPositionInScenery.Y;
            return new(x, y);
        }
        public void SetActualPositionInScenery(Scenery scenery)
        {
            int x = scenery.MapAreaObject.PosX;
            int y = scenery.MapAreaObject.PosY;
            int z = scenery.MapAreaObject.PosZ;
            this.ActualPositionInScenery = new(x, y, z);
        }
        public void StopMoviment()
        {
            this.WalkTrajectory?.Clear();
        }
        public void RunPathfinding()
        {
            this.ResetPathfindingSource?.Cancel();
            this.ResetPathfindingSource = new();
            CancellationToken resetPathfindingToken = this.ResetPathfindingSource.Token;
            Task.Run(() => this.StartPathfinding(resetPathfindingToken), resetPathfindingToken);
        }
        private async Task StartPathfinding(CancellationToken cancellationToken)
        {
            if (this.Scenery != null)
            {
                int userKeyInArea = this.Scenery.GetClientIdentifier(this.Id);
                while (this.Scenery != null)
                {
                    try
                    {
                        if (this.WalkTrajectory != null && this.WalkTrajectory.Positions.Count > 0)
                        {
                            Position nextPosition = this.WalkTrajectory.NextMoviment();
                            if (
                                this.WalkTrajectory.MovementIsVerifield(nextPosition)
                                && this.Scenery.MapAreaObject.IsWalkable(nextPosition.X, nextPosition.Y)
                                )
                            {
                                this.ActualPositionInScenery = nextPosition;
                                this.WalkTrajectory.Positions.Remove(this.ActualPositionInScenery);
                                WalkPacket.Invoke(this, userKeyInArea);
                                await Task.Delay(680, cancellationToken);
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        Console.WriteLine(ex.Message);
                        break;
                    }

                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    await Task.Delay(1, cancellationToken);
                }
                this.WalkTrajectory = null;
            }
        }
    }
}
