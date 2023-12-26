using boombang_emulator.src.Handlers.Scenery.Packets;
using boombang_emulator.src.Pathfinding;
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
        public User(Dictionary<string, object> data)
        {
            this.Id = Convert.ToInt32(data["id"]);
            this.Username = (string)data["username"];
            this.Email = (string)data["email"];
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
            return new(this.ActualPositionInScenery.X, this.ActualPositionInScenery.Y);
        }
        public void SetActualPositionInScenery(Scenery scenery)
        {
            this.ActualPositionInScenery = new(scenery.MapAreaObject.posX, scenery.MapAreaObject.posY, 4);
        }
        public async Task RunPathfinding()
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
                                await Task.Delay(680);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        this.WalkTrajectory = null;
                        break;
                    }
                    await Task.Delay(1);
                }
                this.WalkTrajectory = null;
            }
        }
    }
}
