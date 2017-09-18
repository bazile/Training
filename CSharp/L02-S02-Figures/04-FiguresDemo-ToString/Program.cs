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
                    new Ellipse(3.1, 3.1),
                    new Circle(3.1),
                    // В классе Triangle метод ToString() отсутствует. Обрати внимание на разницу в выводе
                    new Triangle(4.2)
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
