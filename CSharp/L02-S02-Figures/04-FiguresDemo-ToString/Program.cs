using System;

namespace BelhardTraining.FiguresDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure[] figures = new Figure[]
                {
                    new Rectangle(3,4),
                    new Square(3),
                    new Ellipse(2.5, 1.9),
                    new Circle(3.1),
                    // В классе EquilateralTriangle метод ToString() отсутствует. Обрати внимание на разницу в выводе
                    new EquilateralTriangle(3.7)
                };
            foreach (Figure figure in figures)
            {
                // WriteLine автоматически вызывает виртуальный метод ToString()
                // Если наш класс и его базовые классы не реализуют его, то будет вызвана реализация System.Object.ToString()
                Console.WriteLine(figure);
            }
        }
    }
}
