using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public interface IShape
    {
        double Area();
        double Perimeter();
    }

    class Square : IShape
    {
        public double side;
        public double Area()
        {
            return side * side;
        }

        public double Perimeter()
        {
            return side * 4;
        }
    }

    class Circle : IShape
    {
        const double pi = 3.14;
        public double radius;
        public double Area()
        {
            return pi * radius * radius;
        }

        public double Perimeter()
        {
            return 2 * pi * radius;
        }
    }

    public abstract class ShapeFactory
    {
        public IShape GetShape(double dimension)
        {
            IShape shape = this.CreateShape(dimension);
            return shape;
        }

        public abstract IShape CreateShape(double dimension);
    }


    public class CircleFactory : ShapeFactory
    {
        public override IShape CreateShape(double dimension)
        {
            Circle circle = new Circle();
            circle.radius = dimension;
            return circle;
        }
    }

    public class SquareFactory : ShapeFactory
    {
        public override IShape CreateShape(double dimension)
        {
            Square square = new Square();
            square.side = dimension;
            return square;
        }
    }
    class Program
    {
        public static void Main()
        {
            ShapeFactory shape_factory = new SquareFactory();

            IShape shape1 = shape_factory.GetShape(4);
            Console.WriteLine("Shape Area: " + shape1.Area());
            Console.WriteLine("Shape Perimeter: " + shape1.Perimeter());

            shape_factory = new CircleFactory();
            IShape shape2 = shape_factory.GetShape( 3);
            Console.WriteLine("Shape Area: " + shape2.Area());
            Console.WriteLine("Shape Perimeter: " + shape2.Perimeter());

            Console.ReadLine();
        }
    }

}
