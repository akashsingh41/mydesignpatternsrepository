using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    interface IShape
    {
        void Print();
    }

    class Rectangle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Rectangle Print");
        }
    }

    class Circle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Circle Print");
        }
    }

    class ShapeFactory
    {
        Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();
        public int TotalObjectsCreated
        {
            get
            {
                return shapes.Count;
            }
        }

        public IShape GetShape(string _shapename)
        {
            IShape new_shape = null;
            if (shapes.ContainsKey(_shapename))
                new_shape = shapes[_shapename];
            else
            {
                switch (_shapename)
                {
                    case "Rectangle":
                        new_shape = new Rectangle();
                        shapes.Add("Rectangle", new_shape);
                        break;
                    case "Circle":
                        new_shape = new Circle();
                        shapes.Add("Circle", new_shape);
                        break;
                    default:
                        throw new Exception("Factory cannot create the object specified");
                }
            }
            return new_shape;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory sf = new ShapeFactory();
            IShape s = sf.GetShape("Rectangle");
            s.Print();

            s = sf.GetShape("Circle");
            s.Print();

            s = sf.GetShape("Circle");
            s.Print();

            s = sf.GetShape("Rectangle");
            s.Print();

            s = sf.GetShape("Circle");
            s.Print();

            Console.WriteLine("Total Objects created : "+ sf.TotalObjectsCreated);
            Console.ReadLine();
        }
    }
}
