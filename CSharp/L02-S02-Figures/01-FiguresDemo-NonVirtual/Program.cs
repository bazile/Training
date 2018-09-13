using System;

namespace TrainingCenter.FiguresDemo
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
                    new Triangle(4.2),
                };
            foreach (Figure figure in figures)
            {
                PrintFigure(figure.WhoAmI(), figure.GetType().Name, figure.ComputeArea());

                #region Неправильная попытка исправить ошибку с помощью оператора is

                //// Это анти-пример
                //// НИКОГДА НЕ ПИШИТЕ ТАКОЙ КОД!
                ////
                //// 1. Код громоздкий;
                //// 2. Требует изменений в случае переименования/добавления/удаления классов;
                //// 3. Подвержен ошибкам. Одна такая ошибка была внесена в код специально.

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
                //else if (figure is Triangle)
                //{
                //    Triangle triangle = (Triangle)figure;
                //    PrintFigure(triangle.WhoAmI(), triangle.GetType().Name, triangle.ComputeArea());
                //}
                //else // Фигура
                //{
                //    PrintFigure(figure.WhoAmI(), figure.GetType().Name, figure.ComputeArea());
                //}

                #region Чуть более простой, но все еще плохой вариант, использующий возможности C# 7

                //if (figure is Ellipse ellipse)
                //{
                //    PrintFigure(ellipse.WhoAmI(), ellipse.GetType().Name, ellipse.ComputeArea());
                //}
                //else if (figure is Circle circle)
                //{
                //    PrintFigure(circle.WhoAmI(), circle.GetType().Name, circle.ComputeArea());
                //}
                //else if (figure is Square square)
                //{
                //    PrintFigure(square.WhoAmI(), square.GetType().Name, square.ComputeArea());
                //}
                //else if (figure is Rectangle rectangle)
                //{
                //    PrintFigure(rectangle.WhoAmI(), rectangle.GetType().Name, rectangle.ComputeArea());
                //}
                //else if (figure is Triangle triangle)
                //{
                //    PrintFigure(triangle.WhoAmI(), triangle.GetType().Name, triangle.ComputeArea());
                //}
                //else // Фигура
                //{
                //    PrintFigure(figure.WhoAmI(), figure.GetType().Name, figure.ComputeArea());
                //}

                #endregion

                #endregion

                #region Еще одна неправильная попытка исправить код с помощью switch и pattern matching из C# 7

                //// Это анти-пример
                //// Требуется компилятор поддерживающий C# 7 (VS 2017)!
                //// НИКОГДА НЕ ПИШИТЕ ТАКОЙ КОД!

                //switch (figure)
                //{
                //    case Circle circle:
                //        PrintFigure(circle.WhoAmI(), circle.GetType().Name, circle.ComputeArea());
                //        break;
                //    case Ellipse ellipse:
                //        PrintFigure(ellipse.WhoAmI(), ellipse.GetType().Name, ellipse.ComputeArea());
                //        break;
                //    case Square square:
                //        PrintFigure(square.WhoAmI(), square.GetType().Name, square.ComputeArea());
                //        break;
                //    case Rectangle rectangle:
                //        PrintFigure(rectangle.WhoAmI(), rectangle.GetType().Name, rectangle.ComputeArea());
                //        break;
                //    case Triangle triangle:
                //        PrintFigure(triangle.WhoAmI(), triangle.GetType().Name, triangle.ComputeArea());
                //        break;
                //    default:
                //        PrintFigure(figure.WhoAmI(), figure.GetType().Name, figure.ComputeArea());
                //        break;
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
