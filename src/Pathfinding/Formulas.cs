using System.Drawing;

namespace boombang_emulator.src.Pathfinding
{
    internal class Formulas
    {
        public enum AlgorithmicFormulas
        {
            Manhattan, MaxDXDY, DiagonalShortCut, Euclidean, EuclideanNoSQR, Other, Nula
        }
        public static float SolucionAlgoritmica(Point newNode, Point end, float mHEstimate)
        {
            AlgorithmicFormulas FormulaAlgoritmica = AlgorithmicFormulas.Other;
            return FormulaAlgoritmica switch
            {
                AlgorithmicFormulas.Manhattan => Manhattan(newNode, end, mHEstimate),
                AlgorithmicFormulas.MaxDXDY => MaxDXDY(newNode, end, mHEstimate),
                AlgorithmicFormulas.DiagonalShortCut => DiagonalShortCut(newNode, end, mHEstimate),
                AlgorithmicFormulas.Euclidean => Euclidean(newNode, end, mHEstimate),
                AlgorithmicFormulas.EuclideanNoSQR => EuclideanNoSQR(newNode, end, mHEstimate),
                AlgorithmicFormulas.Other => Default(newNode, end, mHEstimate),
                AlgorithmicFormulas.Nula => mHEstimate,
                _ => mHEstimate,
            };
        }
        private static float Manhattan(Point newNode, Point end, float mHEstimate)
        {
            return (float)mHEstimate * (Math.Abs(newNode.X - end.X) + Math.Abs(newNode.Y - end.Y));
        }
        private static float MaxDXDY(Point newNode, Point end, float mHEstimate)
        {
            return (float)mHEstimate * (Math.Max(Math.Abs(newNode.X - end.X), Math.Abs(newNode.Y - end.Y)));
        }
        private static float DiagonalShortCut(Point newNode, Point end, float mHEstimate)
        {
            int h_diagonal = Math.Min(Math.Abs(newNode.X - end.X), Math.Abs(newNode.Y - end.Y));
            int h_straight = Math.Abs(newNode.X - end.X) + Math.Abs(newNode.Y - end.Y);
            return (float)(mHEstimate * 2) * h_diagonal + mHEstimate * (h_straight - 2 * h_diagonal);
        }
        private static float Euclidean(Point newNode, Point end, float mHEstimate)
        {
            return (float)(mHEstimate * Math.Sqrt(Math.Pow(newNode.X - end.X, 2) + Math.Pow(newNode.Y - end.Y, 2)));
        }
        private static float EuclideanNoSQR(Point newNode, Point end, float mHEstimate)
        {
            return (float)(mHEstimate * (Math.Pow((newNode.X - end.X), 2) + Math.Pow(newNode.Y - end.Y, 2)));
        }
        private static float Default(Point newNode, Point end, float mHEstimate)
        {
            Point dxy = new(Math.Abs(end.X - newNode.X), Math.Abs(end.Y - newNode.Y));
            int Orthogonal = Math.Abs(dxy.X - dxy.Y);
            int Diagonal = Math.Abs((dxy.X + dxy.Y - Orthogonal) / 2);
            return (float)mHEstimate * (Diagonal + Orthogonal + dxy.X + dxy.Y);
        }
    }
}

