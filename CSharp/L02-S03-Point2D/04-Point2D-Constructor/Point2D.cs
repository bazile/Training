using System;

namespace TrainingCenter.PointDemo
{
    public class Point2D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
            Color = ConsoleColor.Green;
        }

        public Point2D(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public double CalculateDistance(Point2D other)
        {
            return Math.Sqrt((other.X - X) * (other.X - X) + (other.Y - Y) * (other.Y - Y));
        }

        public void PrintDistance(Point2D other)
        {
            Console.WriteLine("Расстояние между точками ({0},{1}) и ({2},{3}) = {4:F3}", X, Y, other.X, other.Y, CalculateDistance(other));
        }
    }
}
