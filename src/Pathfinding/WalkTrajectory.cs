using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Scenarios;
using System.Drawing;

namespace boombang_emulator.src.Pathfinding
{
    internal class WalkTrajectory
    {
        public Point EndPosition { get; set; }
        public NextStep NextStep { get; set; }
        public Client Client { get; set; }
        public PathFinder PathFinder { get; set; }
        public List<Position> Positions { get; set; }
        public Scenery? Scenery { get; set; }
        public WalkTrajectory(Point endPosition, Client client)
        {
            this.EndPosition = endPosition;
            this.Client = client;
            this.Scenery = client.User?.Scenery;
            this.NextStep = new(endPosition, client);
            this.PathFinder = new(this.NextStep, client);
            this.Positions = [];
            this.SetPositions();
        }
        private void SetPositions()
        {
            this.NextStep = new(this.EndPosition, this.Client);
            this.PathFinder = new(this.NextStep, this.Client);
            List<Point> path = this.PathFinder.FindPath();
            foreach (Point point in path)
            {
                this.Positions.Add(new Position(point.X, point.Y, 0));
            }
        }
        public Position NextMoviment()
        {
            if (this.Scenery == null)
            {
                throw new Exception("-");
            }

            Position NextStep = this.Positions[0];
            if (
                !this.Scenery.MapAreaObject.IsWalkable(NextStep.X, NextStep.Y)
                || this.Scenery.GetClientInPosition(new(NextStep.X, NextStep.Y)) != null
                //|| !Session.User.Sala.WalkByObjects(NextStep.X, NextStep.Y)
                )
            {
                if (this.Positions.Count >= 1)
                {
                    this.Positions.Clear();
                }
                this.SetPositions();
                NextStep = this.Positions[0];
            }
            IsMovementCorrupt(NextStep);
            return NextStep;
        }
        public bool MovementIsVerifield(Position NextStep)
        {
            if (this.Client.User != null && this.Client.User.ActualPositionInScenery != null)
            {
                if (this.Client.User.ActualPositionInScenery.X == NextStep.X + 1 && this.Client.User.ActualPositionInScenery.Y == NextStep.Y + 1) return true;
                if (this.Client.User.ActualPositionInScenery.X == NextStep.X - 1 && this.Client.User.ActualPositionInScenery.Y == NextStep.Y - 1) return true;
                if (this.Client.User.ActualPositionInScenery.X == NextStep.X + 1 && this.Client.User.ActualPositionInScenery.Y == NextStep.Y - 1) return true;
                if (this.Client.User.ActualPositionInScenery.X == NextStep.X - 1 && this.Client.User.ActualPositionInScenery.Y == NextStep.Y + 1) return true;
                if (this.Client.User.ActualPositionInScenery.X == NextStep.X - 1 && this.Client.User.ActualPositionInScenery.Y == NextStep.Y) return true;
                if (this.Client.User.ActualPositionInScenery.X == NextStep.X + 1 && this.Client.User.ActualPositionInScenery.Y == NextStep.Y) return true;
                if (this.Client.User.ActualPositionInScenery.X == NextStep.X && this.Client.User.ActualPositionInScenery.Y == NextStep.Y + 1) return true;
                if (this.Client.User.ActualPositionInScenery.X == NextStep.X && this.Client.User.ActualPositionInScenery.Y == NextStep.Y - 1) return true;
            }
            return false;
        }
        public void Clear()
        {
            this.Positions.Clear();
        }
        public void IsMovementCorrupt(Position NextPoint)
        {
            if (this.Client.User == null || this.Client.User.ActualPositionInScenery == null)
            {
                throw new Exception("-");
            }

            if (NextPoint.X == this.Client.User.ActualPositionInScenery.X && NextPoint.Y == this.Client.User.ActualPositionInScenery.Y)
            {
                this.Positions.Remove(this.Positions[0]);
            }
            if (this.Client.User.ActualPositionInScenery.X == NextPoint.X && this.Client.User.ActualPositionInScenery.Y == NextPoint.Y)
            {
                this.Positions.Remove(this.Positions[0]);
            }
            Position NextStep = NextPoint;
            if (this.Positions.Count >= 1)
            {
                if (this.Positions.Count >= 1)
                {
                    if (this.Client.User.ActualPositionInScenery.X + 2 == NextStep.X)
                    {
                        int Resta = NextStep.X - 1;
                        NextStep.X = Resta;

                    }
                    if (this.Client.User.ActualPositionInScenery.X - 2 == NextStep.X)
                    {
                        int Resta = NextStep.X + 1;
                        NextStep.X = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y - 2 == NextStep.Y)
                    {
                        int Resta = NextStep.Y + 1;
                        NextStep.Y = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y + 2 == NextStep.Y)
                    {
                        int Resta = NextStep.Y - 1;
                        NextStep.Y = Resta;
                    }
                }
                if (this.Positions.Count >= 2)
                {
                    if (this.Client.User.ActualPositionInScenery.X + 3 == NextStep.X)
                    {
                        int Resta = NextStep.X - 2;
                        NextStep.X = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.X - 3 == NextStep.X)
                    {
                        int Resta = NextStep.X + 2;
                        NextStep.X = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y - 3 == NextStep.Y)
                    {
                        int Resta = NextStep.Y + 2;
                        NextStep.Y = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y + 3 == NextStep.Y)
                    {
                        int Resta = NextStep.Y - 2;
                        NextStep.Y = Resta;
                    }
                }
                if (this.Positions.Count >= 3)
                {
                    if (this.Client.User.ActualPositionInScenery.X + 4 == NextStep.X)
                    {
                        int Resta = NextStep.X - 3;
                        NextStep.X = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.X - 4 == NextStep.X)
                    {
                        int Resta = NextStep.X + 3;
                        NextStep.X = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y - 4 == NextStep.Y)
                    {
                        int Resta = NextStep.Y + 3;
                        NextStep.Y = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y + 4 == NextStep.Y)
                    {
                        int Resta = NextStep.Y - 3;
                        NextStep.Y = Resta;
                    }
                }
                if (this.Positions.Count >= 4)
                {
                    if (this.Client.User.ActualPositionInScenery.X + 5 == NextStep.X)
                    {
                        int Resta = NextStep.X - 4;
                        NextStep.X = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.X - 5 == NextStep.X)
                    {
                        int Resta = NextStep.X + 4;
                        NextStep.X = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y - 5 == NextStep.Y)
                    {
                        int Resta = NextStep.Y + 4;
                        NextStep.Y = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y + 5 == NextStep.Y)
                    {
                        int Resta = NextStep.Y - 4;
                        NextStep.Y = Resta;
                    }
                }
                if (this.Positions.Count >= 5)
                {
                    if (this.Client.User.ActualPositionInScenery.X + 6 == NextStep.X)
                    {
                        int Resta = NextStep.X - 5;
                        NextStep.X = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.X - 6 == NextStep.X)
                    {
                        int Resta = NextStep.X + 5;
                        NextStep.X = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y - 6 == NextStep.Y)
                    {
                        int Resta = NextStep.Y + 5;
                        NextStep.Y = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y + 6 == NextStep.Y)
                    {
                        int Resta = NextStep.Y - 5;
                        NextStep.Y = Resta;
                    }
                }
                if (this.Positions.Count >= 6)
                {
                    if (this.Client.User.ActualPositionInScenery.X + 7 == NextStep.X)
                    {
                        int Resta = NextStep.X - 6;
                        NextStep.X = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.X - 7 == NextStep.X)
                    {
                        int Resta = NextStep.X + 6;
                        NextStep.X = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y - 7 == NextStep.Y)
                    {
                        int Resta = NextStep.Y + 6;
                        NextStep.Y = Resta;
                    }
                    if (this.Client.User.ActualPositionInScenery.Y + 7 == NextStep.Y)
                    {
                        int Resta = NextStep.Y - 6;
                        NextStep.Y = Resta;
                    }
                }

            }
            if (this.Client.User.ActualPositionInScenery.X + 1 == NextPoint.X && this.Client.User.ActualPositionInScenery.Y + 1 == NextPoint.Y && NextPoint.Z != 1)
            {
                NextPoint.Z = 1;
            }
            else if (this.Client.User.ActualPositionInScenery.X - 1 == NextPoint.X && this.Client.User.ActualPositionInScenery.Y - 1 == NextPoint.Y && NextPoint.Z != 2)
            {
                NextPoint.Z = 2;
            }
            else if (this.Client.User.ActualPositionInScenery.X + 1 == NextPoint.X && this.Client.User.ActualPositionInScenery.Y - 1 == NextPoint.Y && NextPoint.Z != 3)
            {
                NextPoint.Z = 3;
            }
            else if (this.Client.User.ActualPositionInScenery.X - 1 == NextPoint.X && this.Client.User.ActualPositionInScenery.Y + 1 == NextPoint.Y && NextPoint.Z != 4)
            {
                NextPoint.Z = 4;
            }
            else if (this.Client.User.ActualPositionInScenery.X + 1 == NextPoint.X && this.Client.User.ActualPositionInScenery.Y == NextPoint.Y && NextPoint.Z != 5)
            {
                NextPoint.Z = 5;
            }
            else if (this.Client.User.ActualPositionInScenery.X == NextPoint.X && this.Client.User.ActualPositionInScenery.Y - 1 == NextPoint.Y && NextPoint.Z != 6)
            {
                NextPoint.Z = 6;
            }
            else if (this.Client.User.ActualPositionInScenery.X == NextPoint.X && this.Client.User.ActualPositionInScenery.Y + 1 == NextPoint.Y && NextPoint.Z != 7)
            {
                NextPoint.Z = 7;
            }
            else if (this.Client.User.ActualPositionInScenery.X - 1 == NextPoint.X && this.Client.User.ActualPositionInScenery.Y == NextPoint.Y && NextPoint.Z != 8)
            {
                NextPoint.Z = 8;
            }
        }
    }
}
