using System;

namespace BelhardTraining.PointDemo
{
    class Rectangle2D
    {
        private int _width;
        private int _height;

        public Point2D TopLeft { get; set; }

        public int Width
        {
            get { return _width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Ширина должна быть положительным ненулевым числом.");
                }
                _width = value;
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Высота должна быть положительным ненулевым числом.");
                }
                _height = value;
            }
        }

        public Rectangle2D(int width, int height)
        {
	        Width = width;
	        Height = height;
        }
    }
}
