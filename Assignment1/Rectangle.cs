using System;
namespace Shape
{
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double _length, double _width)
        {
            Length = _length;
            Width = _width;
        }

        public override double Area() => Length * Width;

        public override double Perimeter() => 2 * (Length + Width);
    }
}
