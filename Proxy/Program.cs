using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IMath
    {
        double Add(double x, double y);
        double Subtract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
    }

    class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Subtract(double x, double y) { return x - y; }
        public double Multiply(double x, double y) { return x * y; }
        public double Divide(double x, double y) { return x / y; }
    }

    class MathProxy : IMath
    {
        private Math _math = new Math();
        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }
        public double Subtract(double x, double y)
        {
            return _math.Subtract(x, y);
        }
        public double Multiply(double x, double y)
        {
            return _math.Multiply(x, y);
        }
        public double Divide(double x, double y)
        {
            return _math.Divide(x, y);
        }
    }


class Program
    {
        static void Main(string[] args)
        {
            MathProxy proxy = new MathProxy();

            

            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy.Subtract(4, 2));
            Console.WriteLine("4 * 2 = " + proxy.Multiply(4, 2));
            Console.WriteLine("4 / 2 = " + proxy.Divide(4, 2));

            // Wait for user

            Console.ReadLine();
        }
    }
}
