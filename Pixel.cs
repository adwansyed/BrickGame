using System.Drawing;

namespace BrickGame
{
    class Pixel
    {
        public Pixel(int x, int y)
        {
            X = x;
            Y = y;
            Width = 25;
            Height = 75;
            BackColor = Color.White;
        }

        public Pixel(int x, int y, int width, int height, Color backColor)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            BackColor = backColor;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color BackColor { get; set; }

        public Rectangle ToRectangle()
        {
            return new Rectangle(X, Y, Width, Height);
        }
    }
}
