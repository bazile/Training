using System;
using System.Drawing;

namespace BelhardTraining.FiguresDemo
{
    static class FiguresGenerator
    {
        public static Figure[] GetRandomFigures(System.Drawing.Rectangle boundRect)
        {
            Random rnd = new Random();
            Func<System.Drawing.Rectangle, Random, Figure>[] creators = { RandomRectange, RandomEllipse };
            Figure[] figures = new Figure[rnd.Next(15)];
            for (int i = 0; i < figures.Length; i++)
            {
                var creator = creators[rnd.Next(creators.Length)];
                figures[i] = creator(boundRect, rnd);
            }
            return figures;
        }

        static Rectangle RandomRectange(System.Drawing.Rectangle rect, Random rnd)
        {
            //int x = rnd.Next(this.Width);
            //int y = rnd.Next(this.Height);
            int width = rnd.Next(rect.Width / 4);
            int height = rnd.Next(rect.Height / 4);
            return new Rectangle(Color.Red, RandomPoint(rect, rnd), width, height);
        }

        static Ellipse RandomEllipse(System.Drawing.Rectangle rect, Random rnd)
        {
            //int x = rnd.Next(this.Width);
            //int y = rnd.Next(this.Height);
            int r1 = rnd.Next(rect.Width / 4);
            int r2 = rnd.Next(rect.Height / 4);
            return new Ellipse(Color.Red, RandomPoint(rect, rnd), r1, r2);
        }

        static Point2D RandomPoint(System.Drawing.Rectangle rect, Random rnd)
        {
            return new Point2D(rect.Width, rect.Height);
        }
    }
}
