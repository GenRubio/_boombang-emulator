using boombang_emulator.src.Models;
using System.Drawing;

namespace boombang_emulator.src.Pathfinding
{
    internal class NextStep
    {
        public Point StartLocation { get; set; }
        public Point EndLocation { get; set; }
        public bool[,] Map { get; set; }
        public NextStep(Point endLocation, Client client)
        {
            this.StartLocation = client.User.GetActualPositionInScenery();
            this.EndLocation = endLocation;
            this.Map = client.User.Scenery.MapAreaObject.BoolMap;
        }
    }
}
