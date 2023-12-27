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
        private string Map { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int PosZ { get; set; }
        public bool[,] BoolMap { get; set; }
        public MapArea(Dictionary<string, object> data)
        {
            this.Map = ((string)data["map_area"]).Replace(" ", "");
            this.PosX = Convert.ToInt32(data["door_position_x"]);
            this.PosY = Convert.ToInt32(data["door_position_y"]);
            this.PosZ = Convert.ToInt32(data["door_position_z"]);
  
            string[] Lines = Convert.ToString(this.Map).Split(Convert.ToChar("\n"));
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
