using System;
namespace Shape
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double _radius)
        {
            Radius = _radius;
        }

        public override double Area() => Math.PI * Radius * Radius;

        public override double Perimeter() => 2 * Math.PI * Radius;
    }
}
