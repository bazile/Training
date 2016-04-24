using System;

namespace BelhardTraining.FiguresDemo
{
    public static class Program
    {
        public static void Main()
        {
            Figure[] figures = new Figure[]
                {
                    new Figure(),
                    new Rectangle(3,4),
                    new Square(3),
                    new Ellipse(2.5, 1.9),
                    new Ellipse(3.1, 3.1),
                    new Circle(3.1),
                    new Triangle(2),
                };
            foreach (Figure figure in figures)
            {
                PrintFigure(figure.WhoAmI(), figure.GetType().Name, figure.ComputeArea());

                #region Неправильная попытка исправить код с помощью проверки типа

                //// Это анти-пример
                //// НИКОГДА НЕ ПИШИТЕ ТАКОЙ КОД!

                //if (figure is Ellipse)
                //{
                //    Ellipse ellipse = (Ellipse)figure;
                //    PrintFigure(ellipse.WhoAmI(), ellipse.GetType().Name, ellipse.ComputeArea());
                //}
                //else if (figure is Circle)
                //{
                //    Circle circle = (Circle)figure;
                //    PrintFigure(circle.WhoAmI(), circle.GetType().Name, circle.ComputeArea());
                //}
                //else if (figure is Square)
                //{
                //    Square square = (Square)figure;
                //    PrintFigure(square.WhoAmI(), square.GetType().Name, square.ComputeArea());
                //}
                //else if (figure is Rectangle)
                //{
                //    Rectangle rectangle = (Rectangle)figure;
                //    PrintFigure(rectangle.WhoAmI(), rectangle.GetType().Name, rectangle.ComputeArea());
                //}

                #endregion
            }
        }

        private static void PrintFigure(string whoAmI, string typeName, double area)
        {
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
