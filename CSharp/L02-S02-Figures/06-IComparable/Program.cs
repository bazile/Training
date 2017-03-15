using System;

namespace TrainingCenter.FiguresDemo
{
    class Program
    {
        static void Main()
        {
            Figure[] figures = new Figure[]
                {
                    new Rectangle(3,4),
                    new Square(3),
                    new Ellipse(2.5, 1.9),
                    new Circle(3.1),
                    new Triangle(3.7)
                };
            PrintFigures(figures, "До сортировки");
            Array.Sort(figures);
            PrintFigures(figures, "После сортировки (по возрастанию площади)");
        }

        static void PrintFigures(Figure[] figures, string message)
        {
            Console.WriteLine(" " + message);
            Console.WriteLine("=============================================");
            foreach (Figure figure in figures)
            {
                Console.WriteLine("{0}. Площадь={1:F2}", figure.WhoAmI(), figure.ComputeArea());
            }
            Console.WriteLine();
        }
    }
}
