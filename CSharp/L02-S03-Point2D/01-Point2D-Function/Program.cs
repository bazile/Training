using System;

namespace BelhardTraining.PointDemo
{
    class Program
    {
        static void Main()
        {
            int x1 = 10, y1 = -2;
            int x2 = 5, y2 = 1;
            int x3 = -2, y3 = 7;

            PrintDistance(x1, y1, x2, y2);
            PrintDistance(x2, y2, x3, y3);
            PrintDistance(x3, y3, x1, y1);

            #region Добавляем цвет

            //ConsoleColor color1 = ConsoleColor.Red;
            //ConsoleColor color2 = ConsoleColor.Yellow;
            //ConsoleColor color3 = ConsoleColor.Cyan;

            //Console.WriteLine("--------------------");
            //// В одной из строк есть ошибка!
            //PrintDistance(x1, y1, color1, x2, y2, color2);
            //PrintDistance(x2, y2, color2, x3, y3, color2);
            //PrintDistance(x3, y3, color3, x1, y1, color1);

            #endregion
        }

        private static double CalculateDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        private static void PrintDistance(int x1, int y1, int x2, int y2)
        {
            Console.WriteLine("Расстояние между точками ({0},{1}) и ({2},{3}) = {4:F3}", x1, y1, x2, y2, CalculateDistance(x1, y1, x2, y2));
        }

        #region Добавляем цвет

        private static void PrintDistance(int x1, int y1, ConsoleColor color1, int x2, int y2, ConsoleColor color2)
        {
            Console.Write("Расстояние между точками ");
            PrintCoordinates(x1, y1, color1);
            Console.Write(" и ");
            PrintCoordinates(x2, y2, color2);
            Console.WriteLine(" = {0:F3}", CalculateDistance(x1, y1, x2, y2));
        }

        /// <summary>Печатает пару координат x и y заданным цветом</summary>
        /// <remarks>После завершения метода цвет консоли будет таким же как до её вызова</remarks>
        private static void PrintCoordinates(int x, int y, ConsoleColor textColor)
        {
            ConsoleColor oldForegoundColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.Write("({0},{1})", x, y);
            Console.ForegroundColor = oldForegoundColor;
        }

        #endregion
    }
}
