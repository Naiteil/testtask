using System.Drawing;

namespace OOP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Square square = new Square(5);
            if (square.IsValid)
            {
                Console.WriteLine($"Square ({square}): Perimeter = {square.GetPerimeter()}, Area = {square.GetArea()}");
            }

            Rectangle rectangle = new Rectangle(4, 6);
            if (rectangle.IsValid)
            {
                Console.WriteLine($"Rectangle ({rectangle}): Perimeter = {rectangle.GetPerimeter()}, Area = {rectangle.GetArea()}");
            }

            Circle circle = new Circle(3);
            if (circle.IsValid)
            {
                Console.WriteLine($"Circle ({circle}): Perimeter = {circle.GetPerimeter()}, Area = {circle.GetArea()}");
            }

            Rhombus rhombus = new Rhombus(5, 6, 8);
            if (rhombus.IsValid)
            {
                Console.WriteLine($"Rhombus ({rhombus}): Perimeter = {rhombus.GetPerimeter()}, Area = {rhombus.GetArea()}");
            }
        }
    }

    public abstract class Figure
    {
        public abstract bool IsValid { get; }
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    public class Rectangle : Figure
    {
        public Rectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public int Length { get; }

        public int Width { get; }

        public override bool IsValid => Length > 0 && Width > 0;

        public override double GetArea()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException();
            }

            return Length * Width;
        }

        public override double GetPerimeter()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException();
            }

            return 2 * (Length + Width);
        }

        public override string ToString()
        {
            return $"Length: {Length}, Width: {Width}";
        }
    }

    public class Square : Rectangle
    {
        public Square(int side): base(side, side)
        {
            Side = side;
        }

        public int Side { get; }

        public override string ToString()
        {
            return $"Side: {Side}";
        }
    }

    public class Circle : Figure
    {
        public Circle(int radius)
        {
            Radius = radius;
        }

        public int Radius { get; }

        public override bool IsValid => Radius > 0;

        public override double GetArea()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException();
            }

            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException();
            }

            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Radius: {Radius}";
        }
    }

    public class Rhombus : Figure
    {
        public Rhombus(int side, int firstDiagonal, int secondDiagonal)
        {
            Side = side;
            FirstDiagonal = firstDiagonal;
            SecondDiagonal = secondDiagonal;
        }

        public int Side { get; }

        public int FirstDiagonal { get; }

        public int SecondDiagonal { get; }

        public override bool IsValid
        {
            get
            {
                if (Side <= 0 || FirstDiagonal <= 0 || SecondDiagonal <= 0)
                {
                    return false;
                }

                return Math.Sqrt(Math.Pow(FirstDiagonal / 2.0, 2) + Math.Pow(SecondDiagonal / 2.0, 2)) == Side;
            }
        }

        public override double GetArea()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException();
            }

            return (FirstDiagonal * SecondDiagonal) / 2;
        }

        public override double GetPerimeter()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException();
            }

            return 4 * Side;
        }

        public override string ToString()
        {
            return $"Side: {Side}, First Diagonal: {FirstDiagonal}, SecondDiagonal: {SecondDiagonal}";
        }
    }
}