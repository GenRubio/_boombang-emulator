﻿namespace boombang_emulator.src.Pathfinding
{
    internal class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Position(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}
