using Newtonsoft.Json;
using System.Drawing;

namespace boombang_emulator.src.Models
{
    internal class MapArea
    {
        private int MATRIX_X = -814;
        private int MATRIX_Y = 335;
        private double DIMENSION_X = 80 * 1;
        private double DIMENSION_Y = 40 * 1;
        public int posX { get; set; }
        public int posY { get; set; }
        public bool[,] BoolMap;

        public MapArea(string mapArea, string respawnPositions)
        {
            this.posX = 11;
            this.posY = 11;
 
            mapArea = mapArea.Replace(" ", "");
            string[] Lines = Convert.ToString(mapArea).Split(Convert.ToChar("\n"));
            this.BoolMap = new bool[Lines.Length, Lines[0].Length];
            
            for (int Y = 0; Y < Lines.Length - 1; Y++)
            {
                for (int X = 0; X < Lines[0].Length; X++)
                {
                    this.BoolMap[Y, X] = (Lines[Y][X] == '0') ? true : false;
                }
            }
        }
        public Point GetCoordinates(Point screen)
        {
            int x = Convert.ToInt32(Math.Round(((screen.X - this.MATRIX_X) / this.DIMENSION_X) + ((this.MATRIX_Y - screen.Y) / this.DIMENSION_Y)));
            int y = Convert.ToInt32(Math.Round(((screen.Y - this.MATRIX_Y) / this.DIMENSION_Y) + ((screen.X - this.MATRIX_X) / this.DIMENSION_X)));
            return new Point(x, y);
        }
        public bool IsWalkable(int X, int Y)
        {
            try
            {
                return BoolMap[Y, X];
            }
            catch
            {
                return false;
            }
        }
        public string ShowData()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
