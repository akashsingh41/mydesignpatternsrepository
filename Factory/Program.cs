using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
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

    class ShapeFactory
    {
        public static IShape CreateShape(string shape_name, double dimension)
        {
            switch (shape_name)
            {
                case "square":
                    Square square = new Square();
                    square.side = dimension;
                    return square;
                case "circle":
                    Circle circle = new Circle();
                    circle.radius = dimension;
                    return circle;
                default:
                    return null;
            }
        }
    }

    class Program
    {
        public static void Main()
        {
            IShape shape1 = ShapeFactory.CreateShape("square", 4);
            Console.WriteLine("Shape Area: " + shape1.Area());
            Console.WriteLine("Shape Perimeter: " + shape1.Perimeter());

            IShape shape2 = ShapeFactory.CreateShape("circle", 3);
            Console.WriteLine("Shape Area: " + shape2.Area());
            Console.WriteLine("Shape Perimeter: " + shape2.Perimeter());

            Console.ReadLine();
        }
    }
    
}
