using System;

namespace TrainingCenter.PointDemo
{
    class Program
    {
        static void Main()
        {
            Rectangle2D rect = new Rectangle2D(10, 15);
            Console.WriteLine("Ширина прямоугольника: {0}", rect.Width);
            Console.WriteLine("Высота прямоугольника: {0}", rect.Height);
            Console.WriteLine("Координата левого верхнего угла: ({0},{1})", rect.TopLeft.X, rect.TopLeft.Y);
            
        }
    }
}
