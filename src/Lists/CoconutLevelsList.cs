namespace boombang_emulator.src.Lists
{
    internal class CoconutLevelsList
    {
        public static readonly List<(int Limit, int Level, int FinishLevel)> data =
        [
            (4, 0, 5),
            (9, 1, 10),
            (24, 2, 25),
            (49, 3, 50),
            (74, 4, 75),
            (99, 5, 100),
            (149, 6, 150),
            (199, 7, 200),
            (299, 8, 300),
            (int.MaxValue, 9, 300)
        ];
    }
}
