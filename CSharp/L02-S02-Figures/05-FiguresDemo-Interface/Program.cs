using System;

namespace BelhardTraining.FiguresDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IFigure[] figures = new IFigure[]
                {
                    new Rectangle(3,4),
                    new Square(3),
                    new Ellipse(2.5, 1.9),
                    new Circle(3.1),
                    new EquilateralTriangle(3.7)
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

            ConsoleColor oldColor = Console.ForegroundColor;
            if (whoAmI != typeName) Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(
                "Who Am I = {0}. Type name is {1}. Area={2:F2}",
                whoAmI,
                typeName,
                area
            );

            Console.ForegroundColor = oldColor;
        }
    }
}
