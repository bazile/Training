using System;

namespace BelhardTraining.PointDemo
{
    class Rectangle2D
    {
        private int width;
        private int height;

        public Point2D TopLeft { get; set; }

        public int Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Ширина должна быть положительным ненулевым числом.");
                }
                width = value;
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Высота должна быть положительным ненулевым числом.");
                }
                height = value;
            }
        }

        public Rectangle2D(int width, int height)
        {
	        Width = width;
	        Height = height;
        }
    }
}
