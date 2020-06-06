using System;
namespace Shape
{
    public class Square : Rectangle
    {
        private double Side { get; set; }

        public Square(double _side) : base(_side, _side)
        {
            Side = _side;
        }

        public override double Area() => Side * Side;

        public override double Perimeter() => Side * 4;
    }
}
