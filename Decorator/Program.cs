using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Filtered : ICoffee
    {
        public string Description()
        {
            return "Filtered";
        }

        public double Cost()
        {
            return 1.99;
        }
    }

    public class Espresso: ICoffee
    {
        public string Description()
        {
            return "Espressed";
        }

        public double Cost()
        {
            return 2.99;
        }
    }
    public interface ICoffee
    {
        string Description();
        double Cost();
    }

    public abstract class CondimentDecorator : ICoffee
    {
        ICoffee _coffee;
        protected string _description = "unknown";
        protected double _price = 0.0;
        public CondimentDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public double Cost()
        {
            return _coffee.Cost() + _price;
        }

        public string Description()
        {
            return String.Format("{0},{1}", _coffee.Description(), _description);
        }
    }

    public class MilkDecorator : CondimentDecorator
    {
        public MilkDecorator(ICoffee coffee)
            : base(coffee)
        {
            _description = "Milk";
            _price = 0.19;
        }
    }

    public class ChocolateDecorator : CondimentDecorator
    {
        public ChocolateDecorator(ICoffee coffee)
            : base(coffee)
        {
            _description = "Chocolate";
            _price = 0.29;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mycoffee = new List<ICoffee>
            {
                new ChocolateDecorator(new MilkDecorator(new Espresso())),
                new ChocolateDecorator(new Filtered())
            };
            foreach (var item in mycoffee)
            {
                Console.WriteLine("Description: "+item.Description());
                Console.WriteLine("Price: "+item.Cost());
            }
            Console.ReadLine();
        }
    }
}
