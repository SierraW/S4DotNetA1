using System;
namespace Shape
{
    public class Triangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double _a, double _b, double _c)
        {
            SideA = _a;
            SideB = _b;
            SideC = _c;
        }

        public override double Area()
        { //Heron's formula
            double semiPerimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
        }

        public override double Perimeter() => SideA + SideB + SideC;
    }
}
