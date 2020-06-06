using System;
using System.Collections.Generic;

namespace Shape
{
    public class ShapeController
    {
        private readonly List<double> args;
        private Shape shape;
        private String mode;

        public struct ControllerMode
        {
            public const string Circle = "Circle";
            public const string Rectangle = "Rectangle";
            public const string Square = "Square";
            public const string Triangle = "Triangle";
            public const string NotSet = "NotSet";
            public const string Out = "Out";
        }

        public ShapeController()
        {
            mode = ControllerMode.NotSet;
            args = new List<double>();
            shape = null;
        }

        public void Run(string comm)
        {
            switch (mode)
            {
                case ControllerMode.Circle:
                    ConCircle(comm);
                    break;
                case ControllerMode.Rectangle:
                    ConRectangle(comm);
                    break;
                case ControllerMode.Square:
                    ConSquare(comm);
                    break;
                case ControllerMode.Triangle:
                    ConTriangle(comm);
                    break;
                case ControllerMode.Out:
                    Output(comm);
                    break;
                case ControllerMode.NotSet:
                    switch (comm)
                    {
                        case "c":
                            mode = ControllerMode.Circle;
                            ConCircle();
                            break;
                        case "r":
                            mode = ControllerMode.Rectangle;
                            ConRectangle();
                            break;
                        case "s":
                            mode = ControllerMode.Square;
                            ConSquare();
                            break;
                        case "t":
                            mode = ControllerMode.Triangle;
                            ConTriangle();
                            break;
                        default:
                            Console.WriteLine("Please select shape to process or [Q]uit:\n[C]ircle\n[R]ectangle\n[S]quare\n[T]riangle");
                            break;
                    }
                    break;
            }
        }

        private void ConCircle(string comm=null)
        {
            ContructingShape(new string[] { "radius" }, delegate
            {
                InitShape(new Circle(_radius: args[0]));
                Console.WriteLine(OutputMsg());
            }
            , comm);
        }

        private void ConRectangle(String comm=null)
        {
            ContructingShape(new string[] { "length", "width" }, delegate
            {
                InitShape(new Rectangle(_length: args[0], _width: args[1]));
                Console.WriteLine(OutputMsg());
            }
            , comm);
        }

        private void ConSquare(String comm = null)
        {
            ContructingShape(new string[] { "side" }, delegate
            {
                InitShape(new Square(_side: args[0]));
                Console.WriteLine(OutputMsg());
            }
            , comm);
        }

        private void ConTriangle(string comm=null)
        {
            ContructingShape(new string[]{ "side a", "side b", "side c" }, delegate
            {
                var a = args[0];
                var b = args[1];
                var c = args[2];
                if ( a + b > c && a + c > b && b + c > a)
                {
                    InitShape(new Triangle(a,b,c));
                    Console.WriteLine(OutputMsg());
                } else
                {
                    Console.WriteLine($"Triangle wide three sides: {a}, {b}, {c} does not exist. Please check again. Press [Q] to quit at any time.");
                    args.Clear();
                    ConTriangle();
                }
            }
            , comm);
        }

        private void InitShape(Shape shape)
        {
            args.Clear();
            this.shape = shape;
            mode = ControllerMode.Out;
        }

        private void ContructingShape(string[] requiredParams, Action initShape, string comm = null)
        {
            if (args.Count != requiredParams.Length)
            {
                if (!ProcessInput(comm))
                {
                    if (comm != null)
                    {
                        Console.WriteLine(InputInvaild(comm));
                    }
                    Console.WriteLine(AskForParamsWithDescription(requiredParams[args.Count]));
                }
                else
                {
                    ContructingShape(requiredParams, () => initShape());
                }
            } else
            {
                initShape();
            }
        }

        private void Output(String comm)
        {
            switch (comm)
            {
                case "a":
                case "p":
                case "b":
                    if (comm == "a" || comm == "b")
                    {
                        Console.WriteLine($"Area: {shape.Area()}");
                    }
                    if (comm == "p" || comm == "b")
                    {
                        Console.WriteLine($"Perimeter: {shape.Perimeter()}");
                    }
                    Console.WriteLine("\n\n");
                    break;
                default:
                    Console.WriteLine(InputInvaild(comm));
                    Console.WriteLine(OutputMsg());
                    return;
            }
            mode = ControllerMode.NotSet;
            Run("");
        }

        private bool ProcessInput(string comm)
        {
            if (comm != null)
            {
                bool isDouble = Double.TryParse(comm, out double output);
                if (isDouble && output > 0)
                {
                    args.Add(output);
                    return true;
                }
            }
            return false;
        }

        private string InputInvaild(string comm)
        {
            return $"Invaild input '{comm}', please check again. Press [Q] to quit at any time.";
        }

        private string AskForParamsWithDescription(string des)
        {
            return $"Please enter {mode.ToLower()} {des}:";
        }

        private string OutputMsg()
        {
            return "Please select output:\n[A]rea\n[P]erimeter\n[B]oth";
        }
    }
}
