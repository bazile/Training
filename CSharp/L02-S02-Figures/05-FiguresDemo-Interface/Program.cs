using System;

namespace TrainingCenter.FiguresDemo
{
    class Program
    {
        static void Main()
        {
            IFigure[] figures = new IFigure[]
                {
                    new Rectangle(3,4),
                    new Square(3),
                    new Ellipse(2.5, 1.9),
                    new Ellipse(3.1, 3.1),
                    new Circle(3.1),
                    new Triangle(4.2)
                };
            foreach (IFigure figure in figures)
            {
                PrintFigure(figure);
            }
        }

        private static void PrintFigure(IFigure figure)
        {
            string whoAmI = figure.WhoAmI();
            string typeName = figure.GetType().Name;
            double area = figure.ComputeArea();

            if (whoAmI != typeName) Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(
                "WhoAmI = {0,-9} ; Имя класса {1,-9} ; Площадь={2:F2}",
                whoAmI,
                typeName,
                area
            );

            Console.ResetColor();
        }
    }
}
